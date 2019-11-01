using Microsoft.EntityFrameworkCore.Migrations;

namespace DatabaseModel.Migrations
{
    public partial class Update1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Castling_Game_GameId",
                table: "Castling");

            migrationBuilder.DropForeignKey(
                name: "FK_NormalMoveDabModel_Game_GameId",
                table: "NormalMoveDabModel");

            migrationBuilder.DropForeignKey(
                name: "FK_ProducingPawn_Game_GameId",
                table: "ProducingPawn");

            migrationBuilder.DropForeignKey(
                name: "FK_UsersGames_Game_GameId",
                table: "UsersGames");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Game",
                table: "Game");

            migrationBuilder.RenameTable(
                name: "Game",
                newName: "Games");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Games",
                table: "Games",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Castling_Games_GameId",
                table: "Castling",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_NormalMoveDabModel_Games_GameId",
                table: "NormalMoveDabModel",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProducingPawn_Games_GameId",
                table: "ProducingPawn",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UsersGames_Games_GameId",
                table: "UsersGames",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Castling_Games_GameId",
                table: "Castling");

            migrationBuilder.DropForeignKey(
                name: "FK_NormalMoveDabModel_Games_GameId",
                table: "NormalMoveDabModel");

            migrationBuilder.DropForeignKey(
                name: "FK_ProducingPawn_Games_GameId",
                table: "ProducingPawn");

            migrationBuilder.DropForeignKey(
                name: "FK_UsersGames_Games_GameId",
                table: "UsersGames");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Games",
                table: "Games");

            migrationBuilder.RenameTable(
                name: "Games",
                newName: "Game");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Game",
                table: "Game",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Castling_Game_GameId",
                table: "Castling",
                column: "GameId",
                principalTable: "Game",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_NormalMoveDabModel_Game_GameId",
                table: "NormalMoveDabModel",
                column: "GameId",
                principalTable: "Game",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProducingPawn_Game_GameId",
                table: "ProducingPawn",
                column: "GameId",
                principalTable: "Game",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UsersGames_Game_GameId",
                table: "UsersGames",
                column: "GameId",
                principalTable: "Game",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
