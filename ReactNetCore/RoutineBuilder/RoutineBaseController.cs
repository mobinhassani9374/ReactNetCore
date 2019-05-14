﻿using AutoMapper.QueryableExtensions;
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

            //var result = PropertyConvertorFactory<TDto>.Convert(data);



            return Ok(data);
        }
    }
}
