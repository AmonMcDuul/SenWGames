using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SenWGames.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UselessBox : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Count",
                table: "Game",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "State",
                table: "Game",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Game",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UselessBox_Description",
                table: "Game",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Count",
                table: "Game");

            migrationBuilder.DropColumn(
                name: "State",
                table: "Game");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Game");

            migrationBuilder.DropColumn(
                name: "UselessBox_Description",
                table: "Game");
        }
    }
}
