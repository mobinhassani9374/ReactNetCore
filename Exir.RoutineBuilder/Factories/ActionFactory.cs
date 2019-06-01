using Exir.RoutineBuilder.Dto;
using Exir.RoutineBuilder.Entities;
using Exir.RoutineBuilder.Enums;
using Exir.RoutineBuilder.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Exir.RoutineBuilder.Factories
{
    public class ActionFactory<TDto> where TDto : RoutineDto
    {
        public static List<TDto> Build(List<TDto> data, DashboardType dashboardType, List<RoutineAction> actions, List<RoutineCustomAction> customActions)
        {
            data.ForEach(c =>
            {
                if (dashboardType == DashboardType.New)
                {
                    var newAction = actions.Where(i => i.Step == c.RoutineStep).ToList();

                    var newCustom = customActions
                    .Where(i => i.Step == c.RoutineStep && i.DashboardType == DashboardType.New)
                    .ToList();

                    var removeAction = newCustom
                    .Where(o => !string.IsNullOrEmpty(o.RemoveAction))
                    .Select(o => o.RemoveAction)
                    .ToList();

                    newAction = newAction
                    .Where(o => !removeAction.Contains(o.Action))
                    .ToList();

                    newAction.ForEach(o =>
                    {
                        c.Actions.Add(new RoutineActionDto
                        {
                            IsCustomAction = false,
                            Color = o.Color,
                            Icon = o.Icon,
                            Title = o.Title,
                            Action = o.Action
                        });
                    });

                    newCustom.ForEach(o =>
                    {
                        c.Actions.Add(new RoutineActionDto
                        {
                            Color = o.Color,
                            Icon = o.Icon,
                            Title = o.Title,
                            IsCustomAction = true,
                            ComponentName = o.ComponentName
                        });
                    });
                }

                else
                {
                    data.ForEach(i =>
                    {
                        customActions.ForEach(o =>
                        {
                            i.Actions.Add(new RoutineActionDto
                            {
                                Color = o.Color,
                                Icon = o.Icon,
                                Title = o.Title,
                                IsCustomAction = true,
                                ComponentName = o.ComponentName,
                            });
                        });
                    });
                }
            });

            return data;
        }
    }
}
