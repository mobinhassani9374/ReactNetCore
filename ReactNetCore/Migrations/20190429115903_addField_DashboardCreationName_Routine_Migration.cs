using Microsoft.EntityFrameworkCore.Migrations;

namespace ReactNetCore.Migrations
{
    public partial class addField_DashboardCreationName_Routine_Migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DashboardCreationName",
                table: "Routines",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DashboardCreationName",
                table: "Routines");
        }
    }
}
