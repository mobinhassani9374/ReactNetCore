using Exir.RoutineBuilder.Data;
using Exir.RoutineBuilder.Entities;
using Exir.RoutineBuilder.Enums;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Exir.RoutineBuilder.Infrastructure
{
    public class RoutineBaseRepository<TContext, TEntity> where TEntity : RoutineEntity
        where TContext : RoutineBuilderContext
    {
        private readonly TContext _context;

        public RoutineBaseRepository(TContext context)
        {
            _context = context;
        }

        public IQueryable<TEntity> GetData(RoutineSearchCriteria searchCriteria)
        {
            var query = _context.Set<TEntity>().AsQueryable();

            var steps = GetRoleStep(searchCriteria.RoutineId,
                searchCriteria.RotineRoleTitle);

            var logs = GetUserEntityIds(searchCriteria.RoutineId,
                searchCriteria.UserId,
                searchCriteria.RotineRoleTitle);

            /// ارسال شده ها
            if (searchCriteria.DashboardType == DashboardType.Archived)
            {
                query = query.Where(c => c.RoutineIsFlown == true &&
                c.RoutineIsDone == false &&
                 logs.Any(cu => cu == c.RoutineStep) &&
                 !steps.Any(cu => cu == c.RoutineStep));
            }

            /// تازه ها
            if (searchCriteria.DashboardType == DashboardType.New)
            {
                query = query.Where(c => c.RoutineIsFlown == true &&
                  steps.Any(cu => cu == c.RoutineStep));
            }


            /// پیش نویس ها
            if (searchCriteria.DashboardType == DashboardType.Draft)
            {
                query = query.Where(c => c.RoutineIsFlown == false &&
                  c.OwnerUserId == searchCriteria.UserId &&
                  steps.Any(cu => cu == c.RoutineStep));
            }


            /// خاتمه یافته ها
            if (searchCriteria.DashboardType == DashboardType.Done)
            {
                query = query.Where(c => c.RoutineIsDone == true &&
                  logs.Any(cu => cu == c.RoutineStep));
            }

            return query;
        }

        public void ChangeStep(int id, int routineId, int userId, string action, string description)
        {
            var entity = _context.Set<TEntity>().Find(id);

            if (entity == null)
                throw new Exception($"رکوردی با این شناسه {id} یافت نشد");

            var steps = _context
                .RoutineSteps
                .Where(c => c.RoutineId.Equals(routineId))
                .ToList();

            var doneSteps = DoneSteps(steps);

            var successSteps = SuccessSteps(steps);

            var nextStep = _context
                 .RoutineActions
                 .Where(c => c.Action.Equals(action)
             && c.RoutineId.Equals(routineId)
             && c.Step == entity.RoutineStep)
             .FirstOrDefault()?.Step;

            if (!nextStep.HasValue)
                throw new Exception("بعد از این مرحله استپی وجود ندارد");

            entity.RoutineStep = nextStep.Value;

            if (!entity.RoutineIsFlown)
            {
                entity.RoutineIsFlown = true;
                entity.RoutineFlownDate = DateTime.Now;
            }

            if (doneSteps.Contains(nextStep.Value))
            {
                entity.RoutineIsDone = true;
            }

            if (successSteps.Contains(nextStep.Value))
            {
                entity.RoutineIsSucceeded = true;
            }

            var routineRoleTitle = _context
                .RoutineRoles
                .Where(c => c.StepsJson.Contains($"\"{entity.RoutineStep}\"") && c.RoutineId.Equals(routineId))
                .FirstOrDefault()?.Title;

            _context.Update(entity);

            _context.RoutineLogs.Add(new RoutineLog
            {
                Action = action,
                ActionDate = DateTime.Now,
                Description = description,
                EntityId = id,
                Step = entity.RoutineStep,
                ToStep = nextStep.Value,
                UserId = userId,
                RoutineRoleTitle = routineRoleTitle
            });

            _context.SaveChanges();
        }

        private List<int> DoneSteps(List<RoutineStep> steps)
        {
            var doneSteps = steps.Where(c => !c.F1.HasValue
              && !c.F2.HasValue
              && !c.F3.HasValue
              && !c.F4.HasValue
              && !c.F5.HasValue
              && !c.F6.HasValue
              && !c.F7.HasValue)
              .Select(c => c.Step)
              .ToList();

            return doneSteps;
        }

        private List<int> SuccessSteps(List<RoutineStep> steps)
        {
            var successSteps = new List<int>();

            var doneSteps = DoneSteps(steps);

            doneSteps.ForEach(c =>
            {
                if (steps.Any(i => i.F2.HasValue && i.Step == c))
                {
                    successSteps.Add(c);
                }
            });

            return successSteps;
        }

        /// <summary>
        /// کارتابل چه استپ هایی دارد
        /// </summary>
        /// <param name="routineId"></param>
        /// <param name="dashboardEnum"></param>
        /// <returns></returns>
        private List<int> GetRoleStep(int routineId, string dashboardEnum)
        {
            var role = _context.RoutineRoles
                .FirstOrDefault(q => q.RoutineId == routineId && q.TitleEn == dashboardEnum);

            if (role == null)
                throw new Exception($"داشبوردی با عنوان {dashboardEnum} در روال {routineId} یافت نشد");

            return JsonConvert.DeserializeObject<List<int>>(role.StepsJson);
        }


        /// <summary>
        /// لاگ های کاربر
        /// </summary>
        /// <param name="routineId"></param>
        /// <param name="userId"></param>
        /// <param name="dashboardEnum"></param>
        /// <returns></returns>
        public List<int> GetUserEntityIds(int routineId, int userId, string dashboardEnum)
        {
            var role = _context.RoutineRoles
                .FirstOrDefault(q => q.RoutineId == routineId && q.TitleEn == dashboardEnum);

            var model = _context.RoutineLogs
                .Where(l => l.RoutineId == routineId &&
                            l.UserId == userId &&
                            l.RoutineRoleTitle == role.Title)
                .Select(l => l.EntityId).ToList();

            return model;
        }
    }
}
