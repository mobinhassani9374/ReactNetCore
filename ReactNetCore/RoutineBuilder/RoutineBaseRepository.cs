using Newtonsoft.Json;
using ReactNetCore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReactNetCore.RoutineBuilder
{
    public abstract class RoutineBaseRepository<TEntity> where TEntity : RoutineEntity
    {
        private readonly AppDbContext _context;

        public RoutineBaseRepository(AppDbContext context)
        {
            _context = context;
        }

        public IQueryable<TEntity> GetData(RoutineSearchCriteria searchCriteria)
        {
            var query = _context.Set<TEntity>().AsQueryable();

            var steps = GetRoleStep(searchCriteria.RoutineId,
                searchCriteria.DashboardEnum);

            var logs = GetUserEntityIds(searchCriteria.RoutineId,
                searchCriteria.UserId,
                searchCriteria.DashboardEnum);

            /// ارسال شده ها
            if (searchCriteria.DashboardType == DashboardTypes.Archived)
            {
                query = query.Where(c => c.RoutineIsFlown == true &&
                c.RoutineIsDone == false &&
                 logs.Any(cu => cu == c.RoutineStep) &&
                 !steps.Any(cu => cu == c.RoutineStep));
            }

            /// تازه ها
            if (searchCriteria.DashboardType == DashboardTypes.New)
            {
                query = query.Where(c => c.RoutineIsFlown == true &&
                  steps.Any(cu => cu == c.RoutineStep));
            }


            /// پیش نویس ها
            if (searchCriteria.DashboardType == DashboardTypes.Draft)
            {
                query = query.Where(c => c.RoutineIsFlown == false &&
                  c.OwnerUserId == searchCriteria.UserId &&
                  steps.Any(cu => cu == c.RoutineStep));
            }


            /// خاتمه یافته ها
            if (searchCriteria.DashboardType == DashboardTypes.Done)
            {
                query = query.Where(c => c.RoutineIsDone == true &&
                  logs.Any(cu => cu == c.RoutineStep));
            }

            return query;
        }

        public bool CreateLog(Entities.RoutineLog entity)
        {
            _context.RoutineLogs.Add(entity);
            if (_context.SaveChanges() > 0) return true;
            return false;
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
                .FirstOrDefault(q => q.RoutineId == routineId && q.DashboardEnum == dashboardEnum);

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
                .FirstOrDefault(q => q.RoutineId == routineId && q.DashboardEnum == dashboardEnum);

            var model = _context.RoutineLogs
                .Where(l => l.RoutineId == routineId &&
                            l.UserId == userId &&
                            l.RoutineRoleTitle == role.Title)
                .Select(l => l.EntityId).ToList();

            return model;
        }
    }
}
