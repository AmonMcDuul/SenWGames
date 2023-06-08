using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SenWGames.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class NullableFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GameLobby_Game_GameId",
                table: "GameLobby");

            migrationBuilder.DropForeignKey(
                name: "FK_Groups_GameLobby_GameLobbyId",
                table: "Groups");

            migrationBuilder.DropForeignKey(
                name: "FK_Groups_Player_GroupLeaderId",
                table: "Groups");

            migrationBuilder.AlterColumn<long>(
                name: "GroupLeaderId",
                table: "Groups",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "GameLobbyId",
                table: "Groups",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "GameId",
                table: "GameLobby",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddForeignKey(
                name: "FK_GameLobby_Game_GameId",
                table: "GameLobby",
                column: "GameId",
                principalTable: "Game",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Groups_GameLobby_GameLobbyId",
                table: "Groups",
                column: "GameLobbyId",
                principalTable: "GameLobby",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Groups_Player_GroupLeaderId",
                table: "Groups",
                column: "GroupLeaderId",
                principalTable: "Player",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GameLobby_Game_GameId",
                table: "GameLobby");

            migrationBuilder.DropForeignKey(
                name: "FK_Groups_GameLobby_GameLobbyId",
                table: "Groups");

            migrationBuilder.DropForeignKey(
                name: "FK_Groups_Player_GroupLeaderId",
                table: "Groups");

            migrationBuilder.AlterColumn<long>(
                name: "GroupLeaderId",
                table: "Groups",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "GameLobbyId",
                table: "Groups",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "GameId",
                table: "GameLobby",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_GameLobby_Game_GameId",
                table: "GameLobby",
                column: "GameId",
                principalTable: "Game",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Groups_GameLobby_GameLobbyId",
                table: "Groups",
                column: "GameLobbyId",
                principalTable: "GameLobby",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Groups_Player_GroupLeaderId",
                table: "Groups",
                column: "GroupLeaderId",
                principalTable: "Player",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
