using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReactNetCore.RoutineBuilder.Dto
{
    public class RoutineFullActionDto
    {
        public string Title { get; set; }

        public string Icon { get; set; }

        public string Color { get; set; }

        public bool IsCustomAction { get; set; }

        public string ComponentName { get; set; }

        public List<string> Parameters { get; set; }
    }
}
