using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ford_Hackhathon_YurtSistemi.Migrations
{
    public partial class OccupancyRate_DormLists_tables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OccupancyRate",
                table: "DormLists",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OccupancyRate",
                table: "DormLists");
        }
    }
}
