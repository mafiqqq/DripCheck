using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DripCheckAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddedRelDate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ProductRelDate",
                table: "ProductDetails",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductRelDate",
                table: "ProductDetails");
        }
    }
}
