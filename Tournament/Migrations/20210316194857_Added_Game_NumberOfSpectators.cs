using Microsoft.EntityFrameworkCore.Migrations;

namespace Tournament.Migrations
{
    public partial class Added_Game_NumberOfSpectators : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NumberOfSpectators",
                table: "Games",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumberOfSpectators",
                table: "Games");
        }
    }
}
