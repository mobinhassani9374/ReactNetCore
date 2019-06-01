using System;
using System.Collections.Generic;
using System.Text;

namespace Exir.RoutineBuilder.Dto
{
    public class DoActionDto
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public string Action { get; set; }

        public int RoutineId { get; set; }
    }
}
