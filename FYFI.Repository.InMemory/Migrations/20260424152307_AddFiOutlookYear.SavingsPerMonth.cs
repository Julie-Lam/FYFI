using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FYFI.Repository.InMemory.Migrations
{
    /// <inheritdoc />
    public partial class AddFiOutlookYearSavingsPerMonth : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "SavingsYearly",
                table: "FiOutlookYears",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SavingsYearly",
                table: "FiOutlookYears");
        }
    }
}
