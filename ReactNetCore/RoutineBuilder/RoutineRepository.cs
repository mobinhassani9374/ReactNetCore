using ReactNetCore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ReactNetCore.RoutineBuilder.Dto;
using AutoMapper.QueryableExtensions;

namespace ReactNetCore.RoutineBuilder
{
    public class RoutineRepository
    {
        private readonly AppDbContext _context;

        public RoutineRepository(AppDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// دریافت نقش های کارتابل با شناسه روال
        /// </summary>
        /// <param name="routineId"></param>
        /// <returns></returns>
        public List<RoutineRoleSummaryDto> GetRoles(int routineId)
        {
            var roles = _context
                .RoutineRoles
                .Where(c => c.RoutineId.Equals(routineId))
                .ProjectTo<RoutineRoleSummaryDto>()
                .ToList();

            return roles;
        }
    }
}
