using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace exampledotnetapi.Migrations
{
    /// <inheritdoc />
    public partial class RemoveVatIncludedField : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VatIncluded",
                table: "Expenses");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "VatIncluded",
                table: "Expenses",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }
    }
}
