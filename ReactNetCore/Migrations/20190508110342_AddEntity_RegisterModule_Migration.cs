using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ReactNetCore.Migrations
{
    public partial class AddEntity_RegisterModule_Migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RegisterModules",
                columns: table => new
                {
                    RoutineStep = table.Column<int>(nullable: false),
                    RoutineIsFlown = table.Column<bool>(nullable: false),
                    RoutineIsDone = table.Column<bool>(nullable: false),
                    RoutineFlownDate = table.Column<DateTime>(nullable: true),
                    RoutineStepChangeDate = table.Column<DateTime>(nullable: true),
                    RoutineIsSucceeded = table.Column<bool>(nullable: false),
                    OwnerUserId = table.Column<int>(nullable: false),
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    File = table.Column<string>(nullable: true),
                    SessionDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegisterModules", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RegisterModules");
        }
    }
}
