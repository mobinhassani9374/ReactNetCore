using ReactNetCore.RoutineBuilder.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReactNetCore.RoutineBuilder
{
    public class ActionFactory<TDto> where TDto : RoutineDto
    {
        public static List<TDto> Build(List<TDto> data, DashboardTypes dashboardType, List<RoutineActionSummaryDto> actions, List<RoutineCustomActionSummaryDto> customActions, RoutineSummaryDto routine)
        {
            data.ForEach(c =>
            {
                
            });

            return data;
        }
    }
}
