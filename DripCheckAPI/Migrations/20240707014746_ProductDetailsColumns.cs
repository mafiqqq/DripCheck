using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DripCheckAPI.Migrations
{
    /// <inheritdoc />
    public partial class ProductDetailsColumns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ProductImageUrl",
                table: "ProductDetails",
                newName: "ProductWidth");

            migrationBuilder.AddColumn<string>(
                name: "ProductBattery",
                table: "ProductDetails",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ProductDisplaySize",
                table: "ProductDetails",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ProductDisplayType",
                table: "ProductDetails",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ProductFrontCamera",
                table: "ProductDetails",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ProductHeight",
                table: "ProductDetails",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ProductImageUrl1",
                table: "ProductDetails",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ProductImageUrl2",
                table: "ProductDetails",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ProductImageUrl3",
                table: "ProductDetails",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ProductMemoryRAM",
                table: "ProductDetails",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ProductMemoryROM",
                table: "ProductDetails",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ProductOS",
                table: "ProductDetails",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ProductProcessor",
                table: "ProductDetails",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ProductRearCamera",
                table: "ProductDetails",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ProductResolution",
                table: "ProductDetails",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ProductWeight",
                table: "ProductDetails",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductBattery",
                table: "ProductDetails");

            migrationBuilder.DropColumn(
                name: "ProductDisplaySize",
                table: "ProductDetails");

            migrationBuilder.DropColumn(
                name: "ProductDisplayType",
                table: "ProductDetails");

            migrationBuilder.DropColumn(
                name: "ProductFrontCamera",
                table: "ProductDetails");

            migrationBuilder.DropColumn(
                name: "ProductHeight",
                table: "ProductDetails");

            migrationBuilder.DropColumn(
                name: "ProductImageUrl1",
                table: "ProductDetails");

            migrationBuilder.DropColumn(
                name: "ProductImageUrl2",
                table: "ProductDetails");

            migrationBuilder.DropColumn(
                name: "ProductImageUrl3",
                table: "ProductDetails");

            migrationBuilder.DropColumn(
                name: "ProductMemoryRAM",
                table: "ProductDetails");

            migrationBuilder.DropColumn(
                name: "ProductMemoryROM",
                table: "ProductDetails");

            migrationBuilder.DropColumn(
                name: "ProductOS",
                table: "ProductDetails");

            migrationBuilder.DropColumn(
                name: "ProductProcessor",
                table: "ProductDetails");

            migrationBuilder.DropColumn(
                name: "ProductRearCamera",
                table: "ProductDetails");

            migrationBuilder.DropColumn(
                name: "ProductResolution",
                table: "ProductDetails");

            migrationBuilder.DropColumn(
                name: "ProductWeight",
                table: "ProductDetails");

            migrationBuilder.RenameColumn(
                name: "ProductWidth",
                table: "ProductDetails",
                newName: "ProductImageUrl");
        }
    }
}
