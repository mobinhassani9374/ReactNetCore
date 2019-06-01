using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Exir.RoutineBuilder.Entities;

namespace Exir.RoutineBuilder.Data
{
    public abstract class RoutineBuilderContext : DbContext
    {
        public RoutineBuilderContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Routine> Routines { get; set; }

        public DbSet<RoutineAction> RoutineActions { get; set; }

        public DbSet<RoutineField> RoutineFields { get; set; }

        public DbSet<RoutineLog> RoutineLogs { get; set; }

        public DbSet<RoutineRole> RoutineRoles { get; set; }

        public DbSet<RoutineStep> RoutineSteps { get; set; }

        public DbSet<RoutineCustomAction> RoutineCustomActions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
