using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ReactNetCore.Models;
using ReactNetCore.RoutineBuilder;

namespace ReactNetCore.Controllers
{
    public class RegisterModuleController : Controller
    {
        [HttpPost]
        [Route("api/RegisterModule/manage")]
        public IActionResult Manage([FromBody]RegisterModuleSearchCritria searchModel)
        {
            return Ok();
        }
    }
}