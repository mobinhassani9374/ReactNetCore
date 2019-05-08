using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ReactNetCore.RoutineBuilder.Dto;
using ReactNetCore.RoutineBuilder.Entities;

namespace ReactNetCore.RoutineBuilder
{
    public class RoutineMappingProfile : Profile
    {
        public RoutineMappingProfile()
        {
            CreateMap<RoutineRole, RoutineRoleSummaryDto>().ReverseMap();
            CreateMap<RoutineField, RoutineSummaryDto>().ReverseMap();
        }
    }
}
