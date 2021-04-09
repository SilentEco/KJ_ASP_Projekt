using Microsoft.EntityFrameworkCore.Migrations;

namespace KJ_ASP_Projekt.Data.Migrations
{
    public partial class DeletedPropertiesInUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsOrganizer",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "MiddleName",
                table: "AspNetUsers");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsOrganizer",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "MiddleName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
