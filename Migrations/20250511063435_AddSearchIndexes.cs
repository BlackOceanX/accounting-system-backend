using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace exampledotnetapi.Migrations
{
    /// <inheritdoc />
    public partial class AddSearchIndexes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Expenses_DocumentNumber",
                table: "Expenses",
                column: "DocumentNumber");

            migrationBuilder.CreateIndex(
                name: "IX_Expenses_Project",
                table: "Expenses",
                column: "Project");

            migrationBuilder.CreateIndex(
                name: "IX_Expenses_VendorDetail",
                table: "Expenses",
                column: "VendorDetail");

            migrationBuilder.CreateIndex(
                name: "IX_Expenses_VendorName",
                table: "Expenses",
                column: "VendorName");

            migrationBuilder.CreateIndex(
                name: "IX_ExpenseItems_Description",
                table: "ExpenseItems",
                column: "Description");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Expenses_DocumentNumber",
                table: "Expenses");

            migrationBuilder.DropIndex(
                name: "IX_Expenses_Project",
                table: "Expenses");

            migrationBuilder.DropIndex(
                name: "IX_Expenses_VendorDetail",
                table: "Expenses");

            migrationBuilder.DropIndex(
                name: "IX_Expenses_VendorName",
                table: "Expenses");

            migrationBuilder.DropIndex(
                name: "IX_ExpenseItems_Description",
                table: "ExpenseItems");
        }
    }
}
