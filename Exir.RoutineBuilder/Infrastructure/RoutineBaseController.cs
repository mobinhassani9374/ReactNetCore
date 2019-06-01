using AutoMapper.QueryableExtensions;
using Exir.RoutineBuilder.Data;
using Exir.RoutineBuilder.Dto;
using Exir.RoutineBuilder.ExtensionMethods;
using Exir.RoutineBuilder.Factories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Exir.RoutineBuilder.Infrastructure
{
    public class RoutineBaseController<TContext, TEntity, TSearchCritria, TDto> : Controller where TEntity : RoutineEntity where TSearchCritria : RoutineSearchCriteria where TDto : RoutineDto
        where TContext : RoutineBuilderContext
    {
        protected readonly RoutineBaseRepository<TContext, TEntity> _routineBaseRepository;

        private readonly TContext _context;

        public RoutineBaseController(RoutineBaseRepository<TContext, TEntity> routineBaseRepository,
            TContext context)
        {
            _routineBaseRepository = routineBaseRepository;
            _context = context;
        }

        protected IQueryable<TEntity> GetQueryAble(TSearchCritria searchModel)
        {
            return _routineBaseRepository.GetData(searchModel);
        }

        protected List<object> GetData(TSearchCritria searchModel, IQueryable<TEntity> query)
        {
            var data = query
              .ProjectTo<TDto>()
              .ToList();

            var actions = _context
                 .RoutineActions
                 .Where(c => c.RoutineId.Equals(searchModel.RoutineId))
                 .ToList();

            var customActions = _context
                 .RoutineCustomActions
                 .Where(c => c.RoutineId.Equals(searchModel.RoutineId))
                 .ToList();

            data = ActionFactory<TDto>
                 .Build(data, searchModel.DashboardType, actions, customActions);

            var result = PropertyConvertorFactory<TDto>.Convert(data);

            return result;
        }

        [Route("[controller]/manage")]
        [HttpPost]
        public virtual IActionResult Manage([FromBody]TSearchCritria searchModel)
        {
            var userId = this.GetUserId();

            searchModel.UserId = userId;

            var query = GetQueryAble(searchModel);

            var result = GetData(searchModel, query);

            return Ok(result);
        }

        [HttpPost]
        [Route("[controller]/changeDashboard")]
        public IActionResult ChangeDashboard([FromBody]DoActionDto model)
        {
            var userId = this.GetUserId();

            _routineBaseRepository.ChangeStep(model.Id, model.RoutineId, userId, model.Action, model.Description);

            return Ok();
        }
    }
}
