using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ford_Hackhathon_YurtSistemi.Migrations
{
    public partial class Surname_Tc_StudentLists_tables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Surname",
                table: "StudentLists",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TcNo",
                table: "StudentLists",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Surname",
                table: "StudentLists");

            migrationBuilder.DropColumn(
                name: "TcNo",
                table: "StudentLists");
        }
    }
}
