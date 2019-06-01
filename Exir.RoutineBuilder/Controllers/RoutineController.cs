using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DNTPersianUtils.Core;
using Exir.RoutineBuilder.Data;
using Microsoft.AspNetCore.Mvc;

namespace Exir.RoutineBuilder.Controllers
{
    public class RoutineController : Controller
    {
        private readonly RoutineBuilderContext _context;

        public RoutineController(RoutineBuilderContext context)
        {
            _context = context;
        }

        [Route("api/routine/getrolesWithdashboardcreation/{routineId}")]
        [HttpGet]
        public IActionResult GetRoleWithDashboardCreation(int routineId)
        {
            var roles = _context
                 .RoutineRoles
                 .Where(c => c.RoutineId.Equals(routineId))
                 .ToList();

            var routine = roles.Select(c => c.Routine).FirstOrDefault();

            return Ok(roles);
        }

        [Route("api/routine/{id}")]
        [HttpGet]
        public IActionResult GetRoutine(int id)
        {
            var model = _context
                .Routines
                .FirstOrDefault(c => c.Id.Equals(id));

            if (model == null)
                return StatusCode(410, $"روال با شناسه {id.ToPersianNumbers()} یافت نشد");

            return Ok(model);
        }

        [Route("api/routine/fields/{id}")]
        [HttpGet]
        public IActionResult GetFields(int id)
        {
            var model = _context
                  .RoutineFields
                  .Where(c => c.RoutineId.Equals(id))
                  .ToList();

            return Ok(model);
        }
    }
}
