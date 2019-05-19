using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReactNetCore.RoutineBuilder
{
    public abstract class RoutineSearchCriteria
    {
        public DashboardTypes DashboardType { get; set; }

        public int UserId { get; set; }

        public int RoutineId { get; set; }

        public string DashboardEnum { get; set; }

        public int PageSize { get; set; }

        public int PageNumber { get; set; }
    }
}
