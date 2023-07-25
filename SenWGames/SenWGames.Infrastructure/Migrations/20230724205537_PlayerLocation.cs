using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SenWGames.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class PlayerLocation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RecentLocation",
                table: "Player");

            migrationBuilder.AddColumn<double>(
                name: "LocationX",
                table: "Player",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "LocationY",
                table: "Player",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LocationX",
                table: "Player");

            migrationBuilder.DropColumn(
                name: "LocationY",
                table: "Player");

            migrationBuilder.AddColumn<string>(
                name: "RecentLocation",
                table: "Player",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
