using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Mvc;

namespace Exir.RoutineBuilder.ExtensionMethods
{
    public static class ControllerExtension
    {
        public static int GetUserId(this Controller controller)
        {
            var nameIdentifier = controller
                .HttpContext
                .User
                .Claims
                .FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)
                ?.Value;

            return Convert.ToInt32(nameIdentifier);
        }
    }
}
