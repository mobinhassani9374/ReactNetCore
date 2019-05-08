using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReactNetCore.RoutineBuilder
{
    public interface IRoutineController
    {
        [Route("[controller]/manage")]
        [HttpPost]
        IActionResult Manage<TSearchCritria>(TSearchCritria searchModel) where TSearchCritria : RoutineSearchCriteria;
    }
}
