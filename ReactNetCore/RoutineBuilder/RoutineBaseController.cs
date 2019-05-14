using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Mvc;
using ReactNetCore.ExtensionMethod;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReactNetCore.RoutineBuilder
{
    public class RoutineBaseController<TEntity, TSearchCritria, TDto> : Controller where TEntity : RoutineEntity where TSearchCritria : RoutineSearchCriteria where TDto : RoutineDto
    {
        protected readonly RoutineBaseRepository<TEntity> _routineBaseRepository;
        private readonly RoutineRepository _routineRepository;

        public RoutineBaseController(RoutineBaseRepository<TEntity> routineBaseRepository,
            RoutineRepository routineRepository)
        {
            _routineBaseRepository = routineBaseRepository;
            _routineRepository = routineRepository;
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

            //var result = PropertyConvertorFactory<TDto>.Convert(data);



            return Ok(data);
        }
    }
}
