using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BeatLeader2.Migrations
{
    public partial class UpdatedBeatMapRelationships : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BeatmapScore");

            migrationBuilder.AddColumn<int>(
                name: "ScoreID",
                table: "Beatmap",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Beatmap_ScoreID",
                table: "Beatmap",
                column: "ScoreID");

            migrationBuilder.AddForeignKey(
                name: "FK_Beatmap_Score_ScoreID",
                table: "Beatmap",
                column: "ScoreID",
                principalTable: "Score",
                principalColumn: "ScoreID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Beatmap_Score_ScoreID",
                table: "Beatmap");

            migrationBuilder.DropIndex(
                name: "IX_Beatmap_ScoreID",
                table: "Beatmap");

            migrationBuilder.DropColumn(
                name: "ScoreID",
                table: "Beatmap");

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

            migrationBuilder.CreateIndex(
                name: "IX_BeatmapScore_ScoreID",
                table: "BeatmapScore",
                column: "ScoreID");
        }
    }
}
