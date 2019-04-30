using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ReactNetCore.RoutineBuilder;
using ReactNetCore.RoutineBuilder.Dto;

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

            var routine = roles.Select(c => c.Routine).FirstOrDefault();

            if (routine == null)
                return StatusCode(410, $"روال با شناسه {routine} یافت نشد");

            if (routine.HaveDashboardCreation)
            {
                roles.Add(new RoutineRoleSummaryDto
                {
                    DashboardEnum = routine.DashboardCreationName,
                    Routine = routine,
                    RoutineId = routineId,
                    SortOrder = 0,

                    Id = roles
                    .FirstOrDefault(c => c.DashboardEnum == routine.DashboardCreationName)?.Id ?? -1,

                    StepsJson = roles
                    .FirstOrDefault(c => c.DashboardEnum == routine.DashboardCreationName)?.StepsJson,

                    Title = routine.DashboardCreationTitle,
                    ComponenName = routine.DashboardCreationComponentName
                });
            }

            roles = roles.OrderBy(c => c.SortOrder).ToList();

            return Ok(roles);
        }
    }
}