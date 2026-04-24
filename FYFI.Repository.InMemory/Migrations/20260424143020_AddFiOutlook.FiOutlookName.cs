using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FYFI.Repository.InMemory.Migrations
{
    /// <inheritdoc />
    public partial class AddFiOutlookFiOutlookName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FiOutlookName",
                table: "FiOutlooks",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FiOutlookName",
                table: "FiOutlooks");
        }
    }
}
