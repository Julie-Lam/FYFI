using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FYFI.Repository.InMemory.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreateAndTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FiOutlooks",
                columns: table => new
                {
                    FiOutlookId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FiOutlookName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FiOutlooks", x => x.FiOutlookId);
                });

            migrationBuilder.CreateTable(
                name: "FiOutlookYears",
                columns: table => new
                {
                    FiOutlookYearId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    YearDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Cash = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FiOutlookId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FiOutlookYears", x => x.FiOutlookYearId);
                    table.ForeignKey(
                        name: "FK_FiOutlookYears_FiOutlooks_FiOutlookId",
                        column: x => x.FiOutlookId,
                        principalTable: "FiOutlooks",
                        principalColumn: "FiOutlookId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_FiOutlookYears_FiOutlookId",
                table: "FiOutlookYears",
                column: "FiOutlookId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FiOutlookYears");

            migrationBuilder.DropTable(
                name: "FiOutlooks");
        }
    }
}
