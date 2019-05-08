using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReactNetCore.RoutineBuilder
{
    public interface RoutineBaseController
    {
        IActionResult Manage<TSearchCriteria>(TSearchCriteria searchModel) where TSearchCriteria : RoutineSearchCriteria;
    }
}
