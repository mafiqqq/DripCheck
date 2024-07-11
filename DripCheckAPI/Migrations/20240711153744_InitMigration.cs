using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DripCheckAPI.Migrations
{
    /// <inheritdoc />
    public partial class InitMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Logins",
                columns: table => new
                {
                    LoginId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Logins", x => x.LoginId);
                });

            migrationBuilder.CreateTable(
                name: "ProductDetails",
                columns: table => new
                {
                    ProductDetailId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductModel = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    ProductBrand = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    ProductColor = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    ProductImageUrl1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductImageUrl2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductImageUrl3 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ProductHeight = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductWidth = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductWeight = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductDisplaySize = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductDisplayType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductResolution = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductProcessor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductOS = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductMemoryRAM = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductMemoryROM = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductRearCamera = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductFrontCamera = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductBattery = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductRelDate = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductDetails", x => x.ProductDetailId);
                });

            migrationBuilder.CreateTable(
                name: "WarrantyDetails",
                columns: table => new
                {
                    WarrantyDetailId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExpirationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    WarrantyStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReqDuration = table.Column<int>(type: "int", nullable: false),
                    ReqReason = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WarrantyDetails", x => x.WarrantyDetailId);
                });

            migrationBuilder.CreateTable(
                name: "ProductSerialNumbers",
                columns: table => new
                {
                    ProductSerialNumberId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SerialNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductDetailId = table.Column<int>(type: "int", nullable: false),
                    isAvailable = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductSerialNumbers", x => x.ProductSerialNumberId);
                    table.ForeignKey(
                        name: "FK_ProductSerialNumbers_ProductDetails_ProductDetailId",
                        column: x => x.ProductDetailId,
                        principalTable: "ProductDetails",
                        principalColumn: "ProductDetailId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductOwners",
                columns: table => new
                {
                    ProductOwnerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OwnerFirstName = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    OwnerLastName = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    EmailAddress = table.Column<string>(type: "nvarchar(200)", nullable: false),
                    PhoneNum = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    ProductDetailId = table.Column<int>(type: "int", nullable: false),
                    WarrantyDetailId = table.Column<int>(type: "int", nullable: false),
                    LoginId = table.Column<int>(type: "int", nullable: false),
                    ProductSerialNumberId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductOwners", x => x.ProductOwnerId);
                    table.ForeignKey(
                        name: "FK_ProductOwners_Logins_LoginId",
                        column: x => x.LoginId,
                        principalTable: "Logins",
                        principalColumn: "LoginId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductOwners_ProductDetails_ProductDetailId",
                        column: x => x.ProductDetailId,
                        principalTable: "ProductDetails",
                        principalColumn: "ProductDetailId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductOwners_ProductSerialNumbers_ProductSerialNumberId",
                        column: x => x.ProductSerialNumberId,
                        principalTable: "ProductSerialNumbers",
                        principalColumn: "ProductSerialNumberId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductOwners_WarrantyDetails_WarrantyDetailId",
                        column: x => x.WarrantyDetailId,
                        principalTable: "WarrantyDetails",
                        principalColumn: "WarrantyDetailId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductOwners_LoginId",
                table: "ProductOwners",
                column: "LoginId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductOwners_ProductDetailId",
                table: "ProductOwners",
                column: "ProductDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductOwners_ProductSerialNumberId",
                table: "ProductOwners",
                column: "ProductSerialNumberId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductOwners_WarrantyDetailId",
                table: "ProductOwners",
                column: "WarrantyDetailId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductSerialNumbers_ProductDetailId",
                table: "ProductSerialNumbers",
                column: "ProductDetailId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductOwners");

            migrationBuilder.DropTable(
                name: "Logins");

            migrationBuilder.DropTable(
                name: "ProductSerialNumbers");

            migrationBuilder.DropTable(
                name: "WarrantyDetails");

            migrationBuilder.DropTable(
                name: "ProductDetails");
        }
    }
}
