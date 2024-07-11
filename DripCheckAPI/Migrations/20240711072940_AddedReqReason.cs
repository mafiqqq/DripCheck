using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DripCheckAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddedReqReason : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ReqReason",
                table: "WarrantyDetails",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReqReason",
                table: "WarrantyDetails");
        }
    }
}
