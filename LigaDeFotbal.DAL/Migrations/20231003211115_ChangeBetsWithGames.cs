using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LigaDeFotbal.DAL.Migrations
{
    /// <inheritdoc />
    public partial class ChangeBetsWithGames : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bets_Competitions_CompetitionId",
                table: "Bets");

            migrationBuilder.DropIndex(
                name: "IX_Bets_CompetitionId",
                table: "Bets");

            migrationBuilder.DropColumn(
                name: "CompetitionId",
                table: "Bets");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CompetitionId",
                table: "Bets",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Bets_CompetitionId",
                table: "Bets",
                column: "CompetitionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bets_Competitions_CompetitionId",
                table: "Bets",
                column: "CompetitionId",
                principalTable: "Competitions",
                principalColumn: "Id");
        }
    }
}
