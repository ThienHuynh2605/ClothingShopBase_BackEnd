using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClothingShop.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddRelationshipUserAndUseraccount : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_UsersAccounts_UserId",
                table: "UsersAccounts",
                column: "UserId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_UsersAccounts_Users_UserId",
                table: "UsersAccounts",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UsersAccounts_Users_UserId",
                table: "UsersAccounts");

            migrationBuilder.DropIndex(
                name: "IX_UsersAccounts_UserId",
                table: "UsersAccounts");
        }
    }
}
