using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PharmacyManagementAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddCreatedDateAndUpdatedDate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DateUpdated",
                table: "Pharmacies",
                newName: "UpdatedDate");

            migrationBuilder.RenameColumn(
                name: "DateCreated",
                table: "Pharmacies",
                newName: "CreatedDate");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UpdatedDate",
                table: "Pharmacies",
                newName: "DateUpdated");

            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                table: "Pharmacies",
                newName: "DateCreated");
        }
    }
}
