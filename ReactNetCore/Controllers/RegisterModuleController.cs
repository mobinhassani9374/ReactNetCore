using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ReactNetCore.Data.Entities;
using ReactNetCore.Models;
using ReactNetCore.RoutineBuilder;
using ReactNetCore.ExtensionMethod;

namespace ReactNetCore.Controllers
{
    public class RegisterModuleController : RoutineBaseController<RegisterModule>
    {
        public RegisterModuleController(RoutineBaseRepository<RegisterModule> routineBaseRepository) : base(routineBaseRepository)
        {

        }

        [HttpPost]
        [Route("api/RegisterModule/manage")]
        public IActionResult Manage([FromBody]RegisterModuleSearchCritria searchModel)
        {
            var userId = this.GetUserId();

            searchModel.UserId = userId;
            _routineBaseRepository.GetData(searchModel).ToList();

            return Ok();
        }
    }
}