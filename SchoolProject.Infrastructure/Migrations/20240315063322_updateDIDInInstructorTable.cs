using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolProject.Infrastructure.Migrations
{
	/// <inheritdoc />
	public partial class updateDIDInInstructorTable : Migration
	{
		/// <inheritdoc />
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropForeignKey(
				name: "FK_instructors_departments_DID",
				table: "instructors");

			migrationBuilder.AlterColumn<int>(
				name: "DID",
				table: "instructors",
				type: "int",
				nullable: false,
				defaultValue: 0,
				oldClrType: typeof(int),
				oldType: "int",
				oldNullable: true);



			migrationBuilder.AddForeignKey(
				name: "FK_instructors_departments_DID",
				table: "instructors",
				column: "DID",
				principalTable: "departments",
				principalColumn: "Id",
				onDelete: ReferentialAction.Cascade);
		}

		/// <inheritdoc />
		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropForeignKey(
				name: "FK_instructors_departments_DID",
				table: "instructors");




			migrationBuilder.AlterColumn<int>(
				name: "DID",
				table: "instructors",
				type: "int",
				nullable: true,
				oldClrType: typeof(int),
				oldType: "int");

			migrationBuilder.AddForeignKey(
				name: "FK_instructors_departments_DID",
				table: "instructors",
				column: "DID",
				principalTable: "departments",
				principalColumn: "Id");
		}
	}
}
