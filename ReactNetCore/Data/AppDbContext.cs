using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ReactNetCore.Data.Entities;
using ReactNetCore.RoutineBuilder.Entities;

namespace ReactNetCore.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Routine> Routines { get; set; }

        public DbSet<RoutineAction> RoutineActions { get; set; }

        public DbSet<RoutineLog> RoutineLogs { get; set; }

        public DbSet<RoutineRole> RoutineRoles { get; set; }

        public DbSet<RoutineStep> RoutineSteps { get; set; }

        public DbSet<RoutineField> RoutineFields { get; set; }

        public DbSet<RoutineCustomAction> RoutineCustomActions { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<RegisterModule> RegisterModules { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}