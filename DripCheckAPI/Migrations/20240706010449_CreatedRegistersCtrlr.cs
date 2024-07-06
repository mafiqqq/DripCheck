using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DripCheckAPI.Migrations
{
    /// <inheritdoc />
    public partial class CreatedRegistersCtrlr : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Password",
                table: "Logins",
                newName: "PasswordHash");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PasswordHash",
                table: "Logins",
                newName: "Password");
        }
    }
}
