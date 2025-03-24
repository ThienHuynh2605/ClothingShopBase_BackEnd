using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClothingShop.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddUserAddressTable3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UsersAdresses_Users_UserId",
                table: "UsersAdresses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UsersAdresses",
                table: "UsersAdresses");

            migrationBuilder.RenameTable(
                name: "UsersAdresses",
                newName: "UsersAddresses");

            migrationBuilder.RenameIndex(
                name: "IX_UsersAdresses_UserId",
                table: "UsersAddresses",
                newName: "IX_UsersAddresses_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UsersAddresses",
                table: "UsersAddresses",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UsersAddresses_Users_UserId",
                table: "UsersAddresses",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UsersAddresses_Users_UserId",
                table: "UsersAddresses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UsersAddresses",
                table: "UsersAddresses");

            migrationBuilder.RenameTable(
                name: "UsersAddresses",
                newName: "UsersAdresses");

            migrationBuilder.RenameIndex(
                name: "IX_UsersAddresses_UserId",
                table: "UsersAdresses",
                newName: "IX_UsersAdresses_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UsersAdresses",
                table: "UsersAdresses",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UsersAdresses_Users_UserId",
                table: "UsersAdresses",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
