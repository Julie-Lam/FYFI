using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FYFI.Repository.InMemory.Migrations
{
    /// <inheritdoc />
    public partial class YearDateFromIntToDateTime : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.DropColumn(
                name: "YearDate",
                table: "FiOutlookYears"
                );

            migrationBuilder.AddColumn<DateTime>(
                name: "YearDate",
                table: "FiOutlookYears",
                type: "datetime2",
                nullable: false); 
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "YearDate",
                table: "FiOutlookYears",
                type: "int",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");
        }
    }
}
