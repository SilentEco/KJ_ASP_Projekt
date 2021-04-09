using Microsoft.EntityFrameworkCore.Migrations;

namespace KJ_ASP_Projekt.Data.Migrations
{
    public partial class AddedOrganizerTitle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "OrganizerTitle",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OrganizerTitle",
                table: "AspNetUsers");
        }
    }
}
