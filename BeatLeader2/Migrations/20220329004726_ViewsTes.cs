using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BeatLeader2.Migrations
{
    public partial class ViewsTes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Score_Beatmap_BeatmapID",
                table: "Score");

            migrationBuilder.DropIndex(
                name: "IX_Score_BeatmapID",
                table: "Score");

            migrationBuilder.AlterColumn<string>(
                name: "SongName",
                table: "Song",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Artist",
                table: "Song",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Rank",
                table: "Score",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "BeatmapScore",
                columns: table => new
                {
                    BeatmapID = table.Column<int>(type: "int", nullable: false),
                    ScoreID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BeatmapScore", x => new { x.BeatmapID, x.ScoreID });
                    table.ForeignKey(
                        name: "FK_BeatmapScore_Beatmap_BeatmapID",
                        column: x => x.BeatmapID,
                        principalTable: "Beatmap",
                        principalColumn: "BeatmapID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BeatmapScore_Score_ScoreID",
                        column: x => x.ScoreID,
                        principalTable: "Score",
                        principalColumn: "ScoreID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Player",
                columns: table => new
                {
                    PlayerID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlayerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AccountAge = table.Column<int>(type: "int", nullable: false),
                    PlayerHMD = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlayerPlatform = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Modcount = table.Column<int>(type: "int", nullable: false),
                    LevelsBeaten = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Player", x => x.PlayerID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BeatmapScore_ScoreID",
                table: "BeatmapScore",
                column: "ScoreID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BeatmapScore");

            migrationBuilder.DropTable(
                name: "Player");

            migrationBuilder.AlterColumn<string>(
                name: "SongName",
                table: "Song",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Artist",
                table: "Song",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Rank",
                table: "Score",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Score_BeatmapID",
                table: "Score",
                column: "BeatmapID");

            migrationBuilder.AddForeignKey(
                name: "FK_Score_Beatmap_BeatmapID",
                table: "Score",
                column: "BeatmapID",
                principalTable: "Beatmap",
                principalColumn: "BeatmapID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
