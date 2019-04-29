using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ReactNetCore.RoutineBuilder;

namespace ReactNetCore.Controllers
{
    public class RoutineController : Controller
    {
        private readonly RoutineRepository _routineRepository;

        public RoutineController(RoutineRepository routineRepository)
        {
            _routineRepository = routineRepository;
        }

        [Route("api/routine/getrolesWithdashboardcreation/{routineId}")]
        [HttpGet]
        public IActionResult GetRoleWithDashboardCreation(int routineId)
        {
            var roles = _routineRepository.GetRoles(routineId);

            return Ok();
        }
    }
}