using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolProject.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addAddressAr : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AddressAr",
                table: "students",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AddressAr",
                table: "students");
        }
    }
}
