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
using ReactNetCore.Dto;

namespace ReactNetCore.Controllers
{
    public class RegisterModuleController : RoutineBaseController<RegisterModule, RegisterModuleSearchCritria, RegisterModuleSummaryDto>
    {
        public RegisterModuleController(RoutineBaseRepository<RegisterModule> routineBaseRepository) : base(routineBaseRepository)
        {

        }
    }
}