using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SenWGames.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangeInGroup : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Groups_Player_GroupLeaderId",
                table: "Groups");

            migrationBuilder.DropIndex(
                name: "IX_Groups_GroupLeaderId",
                table: "Groups");

            migrationBuilder.AlterColumn<string>(
                name: "GroupLeaderId",
                table: "Groups",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "GroupLeaderId",
                table: "Groups",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Groups_GroupLeaderId",
                table: "Groups",
                column: "GroupLeaderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Groups_Player_GroupLeaderId",
                table: "Groups",
                column: "GroupLeaderId",
                principalTable: "Player",
                principalColumn: "Id");
        }
    }
}
