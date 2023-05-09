using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrifoyProject.Repository.Migrations
{
    /// <inheritdoc />
    public partial class AllowPlayerFeaturesNull : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_PlayerFeatures_PlayerFeaturesId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_PlayerFeaturesId",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<int>(
                name: "PlayerFeaturesId",
                table: "AspNetUsers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_PlayerFeaturesId",
                table: "AspNetUsers",
                column: "PlayerFeaturesId",
                unique: true,
                filter: "[PlayerFeaturesId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_PlayerFeatures_PlayerFeaturesId",
                table: "AspNetUsers",
                column: "PlayerFeaturesId",
                principalTable: "PlayerFeatures",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_PlayerFeatures_PlayerFeaturesId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_PlayerFeaturesId",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<int>(
                name: "PlayerFeaturesId",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_PlayerFeaturesId",
                table: "AspNetUsers",
                column: "PlayerFeaturesId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_PlayerFeatures_PlayerFeaturesId",
                table: "AspNetUsers",
                column: "PlayerFeaturesId",
                principalTable: "PlayerFeatures",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
