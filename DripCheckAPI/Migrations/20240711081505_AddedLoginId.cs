using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DripCheckAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddedLoginId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Logins",
                newName: "LoginId");

            migrationBuilder.AddColumn<int>(
                name: "LoginId",
                table: "ProductOwners",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ProductOwners_LoginId",
                table: "ProductOwners",
                column: "LoginId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductOwners_Logins_LoginId",
                table: "ProductOwners",
                column: "LoginId",
                principalTable: "Logins",
                principalColumn: "LoginId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductOwners_Logins_LoginId",
                table: "ProductOwners");

            migrationBuilder.DropIndex(
                name: "IX_ProductOwners_LoginId",
                table: "ProductOwners");

            migrationBuilder.DropColumn(
                name: "LoginId",
                table: "ProductOwners");

            migrationBuilder.RenameColumn(
                name: "LoginId",
                table: "Logins",
                newName: "Id");
        }
    }
}
