using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DripCheckAPI.Migrations
{
    /// <inheritdoc />
    public partial class updatemigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "WarrantyOwnerName",
                table: "WarrantyDetails",
                newName: "OwnerLastName");

            migrationBuilder.AddColumn<string>(
                name: "EmailAddress",
                table: "WarrantyDetails",
                type: "nvarchar(200)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "OwnerFirstName",
                table: "WarrantyDetails",
                type: "nvarchar(100)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PhoneNum",
                table: "WarrantyDetails",
                type: "nvarchar(20)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EmailAddress",
                table: "WarrantyDetails");

            migrationBuilder.DropColumn(
                name: "OwnerFirstName",
                table: "WarrantyDetails");

            migrationBuilder.DropColumn(
                name: "PhoneNum",
                table: "WarrantyDetails");

            migrationBuilder.RenameColumn(
                name: "OwnerLastName",
                table: "WarrantyDetails",
                newName: "WarrantyOwnerName");
        }
    }
}
