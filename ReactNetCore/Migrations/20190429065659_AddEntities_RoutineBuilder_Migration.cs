using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ReactNetCore.Migrations
{
    public partial class AddEntities_RoutineBuilder_Migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Routines",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(nullable: true),
                    HaveDashboardCreation = table.Column<bool>(nullable: false),
                    DashboardCreationComponentName = table.Column<string>(nullable: true),
                    TableName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Routines", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RoutineActions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Step = table.Column<int>(nullable: false),
                    Action = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    Icon = table.Column<string>(nullable: true),
                    Color = table.Column<string>(nullable: true),
                    RoutineId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoutineActions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoutineActions_Routines_RoutineId",
                        column: x => x.RoutineId,
                        principalTable: "Routines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RoutineLogs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EntityId = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    ActionDate = table.Column<DateTime>(nullable: false),
                    Step = table.Column<int>(nullable: false),
                    ToStep = table.Column<int>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Action = table.Column<string>(nullable: true),
                    RoutineRoleTitle = table.Column<string>(nullable: true),
                    RoutineId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoutineLogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoutineLogs_Routines_RoutineId",
                        column: x => x.RoutineId,
                        principalTable: "Routines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RoutineRoles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(nullable: true),
                    StepsJson = table.Column<string>(nullable: true),
                    DashboardEnum = table.Column<string>(nullable: true),
                    SortOrder = table.Column<int>(nullable: false),
                    RoutineId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoutineRoles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoutineRoles_Routines_RoutineId",
                        column: x => x.RoutineId,
                        principalTable: "Routines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RoutineSteps",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(nullable: true),
                    Step = table.Column<int>(nullable: false),
                    F1 = table.Column<int>(nullable: true),
                    F2 = table.Column<int>(nullable: true),
                    F3 = table.Column<int>(nullable: true),
                    F4 = table.Column<int>(nullable: true),
                    F5 = table.Column<int>(nullable: true),
                    F6 = table.Column<int>(nullable: true),
                    F7 = table.Column<int>(nullable: true),
                    RoutineId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoutineSteps", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoutineSteps_Routines_RoutineId",
                        column: x => x.RoutineId,
                        principalTable: "Routines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RoutineActions_RoutineId",
                table: "RoutineActions",
                column: "RoutineId");

            migrationBuilder.CreateIndex(
                name: "IX_RoutineLogs_RoutineId",
                table: "RoutineLogs",
                column: "RoutineId");

            migrationBuilder.CreateIndex(
                name: "IX_RoutineRoles_RoutineId",
                table: "RoutineRoles",
                column: "RoutineId");

            migrationBuilder.CreateIndex(
                name: "IX_RoutineSteps_RoutineId",
                table: "RoutineSteps",
                column: "RoutineId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RoutineActions");

            migrationBuilder.DropTable(
                name: "RoutineLogs");

            migrationBuilder.DropTable(
                name: "RoutineRoles");

            migrationBuilder.DropTable(
                name: "RoutineSteps");

            migrationBuilder.DropTable(
                name: "Routines");
        }
    }
}
