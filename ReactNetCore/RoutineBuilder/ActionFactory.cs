using ReactNetCore.RoutineBuilder.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReactNetCore.RoutineBuilder
{
    public class ActionFactory<TDto> where TDto : RoutineDto
    {
        public static List<TDto> Build(List<TDto> data, DashboardTypes dashboardType, List<RoutineActionSummaryDto> actions, List<RoutineCustomActionSummaryDto> customActions)
        {
            data.ForEach(c =>
            {
                if (dashboardType == DashboardTypes.New)
                {
                    var newAction = actions.Where(i => i.Step == c.RoutineStep).ToList();

                    var newCustom = customActions
                    .Where(i => i.Step == c.RoutineStep && i.DashboardType == DashboardTypes.New)
                    .ToList();

                    var removeAction = newCustom
                    .Where(o => !string.IsNullOrEmpty(o.RemoveAction))
                    .Select(o => o.RemoveAction)
                    .ToList();

                    newAction = newAction
                    .Where(o => removeAction.Contains(o.Action))
                    .ToList();

                    newAction.ForEach(o =>
                    {
                        c.Actions.Add(new RoutineFullActionDto
                        {
                            IsCustomAction = false,
                            Color = o.Color,
                            Icon = o.Icon,
                            Title = o.Title,
                            Parameters = new List<string>()
                             {
                                 "action",
                                 "description",
                                 "id"
                             }
                        });
                    });

                    newCustom.ForEach(o =>
                    {
                        c.Actions.Add(new RoutineFullActionDto
                        {
                            Color = o.Color,
                            Icon = o.Icon,
                            Title = o.Title,
                            IsCustomAction = true,
                            ComponentName = o.ComponentName
                        });
                    });
                }

                if (dashboardType == DashboardTypes.Draft)
                {
                    data.ForEach(i=> 
                    {

                    });
                }
            });

            return data;
        }
    }
}
