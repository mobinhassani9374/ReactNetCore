using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ReactNetCore.RoutineBuilder
{
    public class RoutineBuilderContext : DbContext
    {
        public RoutineBuilderContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Entities.Routine> Routines { get; set; }

        public DbSet<Entities.RoutineAction> RoutineActions { get; set; }

        public DbSet<Entities.RoutineLog> RoutineLogs { get; set; }

        public DbSet<Entities.RoutineRole> RoutineRoles { get; set; }

        public DbSet<Entities.RoutineStep> RoutineSteps { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
