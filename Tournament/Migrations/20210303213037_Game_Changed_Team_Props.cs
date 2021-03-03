using Microsoft.EntityFrameworkCore.Migrations;

namespace Tournament.Migrations
{
    public partial class Game_Changed_Team_Props : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Games_Teams_Team_AID",
                table: "Games");

            migrationBuilder.DropForeignKey(
                name: "FK_Games_Teams_Team_BID",
                table: "Games");

            migrationBuilder.DropIndex(
                name: "IX_Games_Team_AID",
                table: "Games");

            migrationBuilder.DropIndex(
                name: "IX_Games_Team_BID",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "Team_AID",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "Team_BID",
                table: "Games");

            migrationBuilder.AddColumn<int>(
                name: "Team_A",
                table: "Games",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Team_B",
                table: "Games",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Team_A",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "Team_B",
                table: "Games");

            migrationBuilder.AddColumn<int>(
                name: "Team_AID",
                table: "Games",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Team_BID",
                table: "Games",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Games_Team_AID",
                table: "Games",
                column: "Team_AID");

            migrationBuilder.CreateIndex(
                name: "IX_Games_Team_BID",
                table: "Games",
                column: "Team_BID");

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Teams_Team_AID",
                table: "Games",
                column: "Team_AID",
                principalTable: "Teams",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Teams_Team_BID",
                table: "Games",
                column: "Team_BID",
                principalTable: "Teams",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
