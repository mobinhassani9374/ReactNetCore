using System;
using System.Collections.Generic;
using System.Text;

namespace Exir.RoutineBuilder.Dto
{
    public class RoutineActionDto
    {
        public string Title { get; set; }

        public string Icon { get; set; }

        public string Color { get; set; }

        public string Action { get; set; }

        public bool IsCustomAction { get; set; }

        public string ComponentName { get; set; }
    }
}
