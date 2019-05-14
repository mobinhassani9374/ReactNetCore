using ReactNetCore.RoutineBuilder.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReactNetCore.RoutineBuilder
{
    public class RoutineDto : RoutineEntity
    {
        public List<RoutineFullActionDto> Actions { get; set; }
    }
}
