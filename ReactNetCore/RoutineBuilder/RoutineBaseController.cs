using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Mvc;
using ReactNetCore.ExtensionMethod;
using ReactNetCore.RoutineBuilder.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReactNetCore.RoutineBuilder
{
    public class RoutineBaseController<TEntity, TSearchCritria, TDto> : Controller where TEntity : RoutineEntity where TSearchCritria : RoutineSearchCriteria where TDto : RoutineDto
    {
        protected readonly RoutineBaseRepository<TEntity> _routineBaseRepository;

        public RoutineBaseController(RoutineBaseRepository<TEntity> routineBaseRepository)
        {
            _routineBaseRepository = routineBaseRepository;
        }

        [HttpPost]
        [Route("[controller]/manage")]
        public virtual IActionResult Manage([FromBody]TSearchCritria searchModel)
        {
            var userId = this.GetUserId();

            searchModel.UserId = userId;

            var query = _routineBaseRepository.GetData(searchModel);

            var data = query
                .ProjectTo<TDto>()
                .ToList();

            var actions = _routineBaseRepository
                 .RoutineRepository
                 .GetActions(searchModel.RoutineId);

            var customActions = _routineBaseRepository
                 .RoutineRepository
                 .GetCustomActions(searchModel.RoutineId);

            data = ActionFactory<TDto>
                 .Build(data, searchModel.DashboardType, actions, customActions);

            var result = PropertyConvertorFactory<TDto>.Convert(data);





            return Ok(result);
        }

        [HttpPost]
        [Route("[controller]/changeDashboard")]
        public virtual IActionResult ChangeDashboard([FromBody]DoActionDto model)
        {
            var userId = this.GetUserId();

            _routineBaseRepository.ChangeStep(model.Id, model.RoutineId, userId, model.Action, model.Description);

            return Ok();
        }
    }
}
