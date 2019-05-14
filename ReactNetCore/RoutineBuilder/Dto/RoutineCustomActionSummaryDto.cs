using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReactNetCore.RoutineBuilder.Dto
{
    public class RoutineCustomActionSummaryDto
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Icon { get; set; }

        public string Color { get; set; }

        public DashboardTypes DashboardType { get; set; }

        public int? Step { get; set; }

        public string RemoveAction { get; set; }

        public virtual RoutineSummaryDto Routine { get; set; }

        public int RoutineId { get; set; }
    }
}
