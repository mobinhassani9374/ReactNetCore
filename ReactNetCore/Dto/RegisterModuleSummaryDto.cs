using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReactNetCore.Dto
{
    public class RegisterModuleSummaryDto : RoutineBuilder.RoutineDto
    {
        public int Id { get; set; }

        public string File { get; set; }

        public DateTime? SessionDate { get; set; }
    }
}
