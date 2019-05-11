using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Mvc;
using ReactNetCore.ExtensionMethod;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReactNetCore.RoutineBuilder
{
    public class RoutineBaseController<TEntity, TSearchCritria, TDto> : Controller where TEntity : RoutineEntity where TSearchCritria : RoutineSearchCriteria where TDto : class
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

            var result = new List<object>();

            var obj = typeof(TDto);

            var properties = obj.GetProperties();

            data.ForEach(c =>
            {
                var dynamic = new System.Dynamic.ExpandoObject();

                var p = dynamic as IDictionary<String, object>;

                for (int i = 0; i < properties.Length; i++)
                {
                    var propInfo = c.GetType().GetProperty(properties[i].Name);
                    p[properties[i].Name] = propInfo.GetValue(data).ToString();
                }

                result.Add(p);
            });

            var rjiesult = PropertyConvertorFactory<TDto>.Convert(data);

            return Ok(result);
        }
    }
}
