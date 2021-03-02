using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Tournament.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Coach = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    State = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    teamAID = table.Column<int>(type: "int", nullable: true),
                    teamBID = table.Column<int>(type: "int", nullable: true),
                    TeamA_score = table.Column<int>(type: "int", nullable: false),
                    TeamB_score = table.Column<int>(type: "int", nullable: false),
                    WinnerID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Games_Teams_teamAID",
                        column: x => x.teamAID,
                        principalTable: "Teams",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Games_Teams_teamBID",
                        column: x => x.teamBID,
                        principalTable: "Teams",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Games_Teams_WinnerID",
                        column: x => x.WinnerID,
                        principalTable: "Teams",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Games_teamAID",
                table: "Games",
                column: "teamAID");

            migrationBuilder.CreateIndex(
                name: "IX_Games_teamBID",
                table: "Games",
                column: "teamBID");

            migrationBuilder.CreateIndex(
                name: "IX_Games_WinnerID",
                table: "Games",
                column: "WinnerID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Games");

            migrationBuilder.DropTable(
                name: "Teams");
        }
    }
}
