using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolProject.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class changePeriodTypeToint : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Period",
                table: "subjects",
                type: "int",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Period",
                table: "subjects",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
