using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LigaDeFotbal.DAL.Migrations
{
    /// <inheritdoc />
    public partial class RemoveIdFromGame : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Id",
                table: "Games");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Games",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
