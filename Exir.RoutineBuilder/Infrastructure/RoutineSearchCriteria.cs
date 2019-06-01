using Exir.RoutineBuilder.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Exir.RoutineBuilder.Infrastructure
{
    public abstract class RoutineSearchCriteria
    {
        public DashboardType DashboardType { get; set; }

        public int UserId { get; set; }

        public int RoutineId { get; set; }

        public string RotineRoleTitle { get; set; }

        public int PageSize { get; set; }

        public int PageNumber { get; set; }
    }
}
