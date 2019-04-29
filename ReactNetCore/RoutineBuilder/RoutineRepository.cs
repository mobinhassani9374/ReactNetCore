using Newtonsoft.Json;
using ReactNetCore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReactNetCore.RoutineBuilder
{
    public abstract class RoutineRepository<TEntity> where TEntity : RoutineEntity
    {
        private readonly AppDbContext _context;

        public RoutineRepository(AppDbContext context)
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
                
            }

            /// تازه ها
            if (searchCriteria.DashboardType == DashboardTypes.New)
            {

            }


            /// پیش نویس ها
            if (searchCriteria.DashboardType == DashboardTypes.Draft)
            {

            }


            /// خاتمه یافته ها
            if (searchCriteria.DashboardType == DashboardTypes.Done)
            {

            }

            return query;
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
