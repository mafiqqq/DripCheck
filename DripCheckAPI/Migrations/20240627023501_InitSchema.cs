using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DripCheckAPI.Migrations
{
    /// <inheritdoc />
    public partial class InitSchema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Logins",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Logins", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductDetails",
                columns: table => new
                {
                    SerialNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    ProductModel = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    ProductBrand = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    ProductColor = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    ProductImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductDetails", x => x.SerialNumber);
                });

            migrationBuilder.CreateTable(
                name: "WarrantyDetails",
                columns: table => new
                {
                    WarrantyDetailId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OwnerFirstName = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    OwnerLastName = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    EmailAddress = table.Column<string>(type: "nvarchar(200)", nullable: false),
                    PhoneNum = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    ExpirationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProductSerialNumber = table.Column<string>(type: "nvarchar(20)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WarrantyDetails", x => x.WarrantyDetailId);
                    table.ForeignKey(
                        name: "FK_WarrantyDetails_ProductDetails_ProductSerialNumber",
                        column: x => x.ProductSerialNumber,
                        principalTable: "ProductDetails",
                        principalColumn: "SerialNumber",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WarrantyDetails_ProductSerialNumber",
                table: "WarrantyDetails",
                column: "ProductSerialNumber");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Logins");

            migrationBuilder.DropTable(
                name: "WarrantyDetails");

            migrationBuilder.DropTable(
                name: "ProductDetails");
        }
    }
}
