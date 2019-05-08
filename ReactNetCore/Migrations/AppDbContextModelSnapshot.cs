﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ReactNetCore.Data;

namespace ReactNetCore.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ReactNetCore.Data.Entities.RegisterModule", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("File");

                    b.Property<int>("OwnerUserId");

                    b.Property<DateTime?>("RoutineFlownDate");

                    b.Property<bool>("RoutineIsDone");

                    b.Property<bool>("RoutineIsFlown");

                    b.Property<bool>("RoutineIsSucceeded");

                    b.Property<int>("RoutineStep");

                    b.Property<DateTime?>("RoutineStepChangeDate");

                    b.Property<DateTime?>("SessionDate");

                    b.HasKey("Id");

                    b.ToTable("RegisterModules");
                });

            modelBuilder.Entity("ReactNetCore.Data.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FullName");

                    b.Property<string>("Password");

                    b.Property<string>("UserName");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("ReactNetCore.RoutineBuilder.Entities.Routine", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DashboardCreationComponentName");

                    b.Property<string>("DashboardCreationName");

                    b.Property<string>("DashboardCreationTitle");

                    b.Property<bool>("HaveDashboardCreation");

                    b.Property<string>("TableName");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.ToTable("Routines");
                });

            modelBuilder.Entity("ReactNetCore.RoutineBuilder.Entities.RoutineAction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Action");

                    b.Property<string>("Color");

                    b.Property<string>("Icon");

                    b.Property<int>("RoutineId");

                    b.Property<int>("Step");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.HasIndex("RoutineId");

                    b.ToTable("RoutineActions");
                });

            modelBuilder.Entity("ReactNetCore.RoutineBuilder.Entities.RoutineField", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("RoutineId");

                    b.Property<string>("Title");

                    b.Property<string>("TitleEn");

                    b.HasKey("Id");

                    b.HasIndex("RoutineId");

                    b.ToTable("RoutineFields");
                });

            modelBuilder.Entity("ReactNetCore.RoutineBuilder.Entities.RoutineLog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Action");

                    b.Property<DateTime>("ActionDate");

                    b.Property<string>("Description");

                    b.Property<int>("EntityId");

                    b.Property<int>("RoutineId");

                    b.Property<string>("RoutineRoleTitle");

                    b.Property<int>("Step");

                    b.Property<int?>("ToStep");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("RoutineId");

                    b.ToTable("RoutineLogs");
                });

            modelBuilder.Entity("ReactNetCore.RoutineBuilder.Entities.RoutineRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DashboardEnum");

                    b.Property<int>("RoutineId");

                    b.Property<int>("SortOrder");

                    b.Property<string>("StepsJson");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.HasIndex("RoutineId");

                    b.ToTable("RoutineRoles");
                });

            modelBuilder.Entity("ReactNetCore.RoutineBuilder.Entities.RoutineStep", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("F1");

                    b.Property<int?>("F2");

                    b.Property<int?>("F3");

                    b.Property<int?>("F4");

                    b.Property<int?>("F5");

                    b.Property<int?>("F6");

                    b.Property<int?>("F7");

                    b.Property<int>("RoutineId");

                    b.Property<int>("Step");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.HasIndex("RoutineId");

                    b.ToTable("RoutineSteps");
                });

            modelBuilder.Entity("ReactNetCore.RoutineBuilder.Entities.RoutineAction", b =>
                {
                    b.HasOne("ReactNetCore.RoutineBuilder.Entities.Routine", "Routine")
                        .WithMany("Actions")
                        .HasForeignKey("RoutineId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ReactNetCore.RoutineBuilder.Entities.RoutineField", b =>
                {
                    b.HasOne("ReactNetCore.RoutineBuilder.Entities.Routine", "Routine")
                        .WithMany("Fields")
                        .HasForeignKey("RoutineId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ReactNetCore.RoutineBuilder.Entities.RoutineLog", b =>
                {
                    b.HasOne("ReactNetCore.RoutineBuilder.Entities.Routine", "Routine")
                        .WithMany("Logs")
                        .HasForeignKey("RoutineId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ReactNetCore.RoutineBuilder.Entities.RoutineRole", b =>
                {
                    b.HasOne("ReactNetCore.RoutineBuilder.Entities.Routine", "Routine")
                        .WithMany("Roles")
                        .HasForeignKey("RoutineId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ReactNetCore.RoutineBuilder.Entities.RoutineStep", b =>
                {
                    b.HasOne("ReactNetCore.RoutineBuilder.Entities.Routine", "Routine")
                        .WithMany("Steps")
                        .HasForeignKey("RoutineId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
