using Microsoft.EntityFrameworkCore.Migrations;

namespace Tournament.Migrations
{
    public partial class ChangedPropInGameClass2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Winner",
                table: "Games");

            migrationBuilder.AddColumn<int>(
                name: "WinnerID",
                table: "Games",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Games_WinnerID",
                table: "Games",
                column: "WinnerID");

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Teams_WinnerID",
                table: "Games",
                column: "WinnerID",
                principalTable: "Teams",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Games_Teams_WinnerID",
                table: "Games");

            migrationBuilder.DropIndex(
                name: "IX_Games_WinnerID",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "WinnerID",
                table: "Games");

            migrationBuilder.AddColumn<int>(
                name: "Winner",
                table: "Games",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
