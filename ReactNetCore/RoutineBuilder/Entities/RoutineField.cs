using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReactNetCore.RoutineBuilder.Entities
{
    public class RoutineField
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string TitleEn { get; set; }

        public virtual Routine Routine { get; set; }

        public int RoutineId { get; set; }
    }
}
