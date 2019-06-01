using Exir.RoutineBuilder.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Exir.RoutineBuilder.Entities
{
    public class RoutineCustomAction
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Icon { get; set; }

        public string Color { get; set; }

        public DashboardType DashboardType { get; set; }

        public int? Step { get; set; }

        public string ComponentName { get; set; }

        public string RelativePath { get; set; }

        public string RemoveAction { get; set; }

        public virtual Routine Routine { get; set; }

        public int RoutineId { get; set; }
    }
}
