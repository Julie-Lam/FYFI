using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FYFI.Repository.InMemory.Migrations
{
    /// <inheritdoc />
    public partial class AddARequiredFKRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FiOutlookYears_FiOutlooks_FiOutlookId",
                table: "FiOutlookYears");

            migrationBuilder.AlterColumn<int>(
                name: "FiOutlookId",
                table: "FiOutlookYears",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_FiOutlookYears_FiOutlooks_FiOutlookId",
                table: "FiOutlookYears",
                column: "FiOutlookId",
                principalTable: "FiOutlooks",
                principalColumn: "FiOutlookId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FiOutlookYears_FiOutlooks_FiOutlookId",
                table: "FiOutlookYears");

            migrationBuilder.AlterColumn<int>(
                name: "FiOutlookId",
                table: "FiOutlookYears",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_FiOutlookYears_FiOutlooks_FiOutlookId",
                table: "FiOutlookYears",
                column: "FiOutlookId",
                principalTable: "FiOutlooks",
                principalColumn: "FiOutlookId");
        }
    }
}
