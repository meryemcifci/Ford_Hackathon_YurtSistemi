using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ford_Hackhathon_YurtSistemi.Migrations
{
    public partial class Capacity_DormLists_tables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Capacity",
                table: "DormLists",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CurrentOccupancy",
                table: "DormLists",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Capacity",
                table: "DormLists");

            migrationBuilder.DropColumn(
                name: "CurrentOccupancy",
                table: "DormLists");
        }
    }
}
