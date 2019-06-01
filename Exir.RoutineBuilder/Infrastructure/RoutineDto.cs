using Exir.RoutineBuilder.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Exir.RoutineBuilder.Infrastructure
{
    public abstract class RoutineDto : RoutineEntity
    {
        public List<RoutineActionDto> Actions { get; set; }
        = new List<RoutineActionDto>();
    }
}
