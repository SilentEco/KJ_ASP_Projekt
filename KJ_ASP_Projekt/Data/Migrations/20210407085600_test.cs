using Microsoft.EntityFrameworkCore.Migrations;

namespace KJ_ASP_Projekt.Data.Migrations
{
    public partial class test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "TestBool",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "TestString",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TestBool",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "TestString",
                table: "AspNetUsers");
        }
    }
}
