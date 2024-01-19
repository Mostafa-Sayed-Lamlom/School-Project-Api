using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolProject.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addConfigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_studentSubjects",
                table: "studentSubjects");

            migrationBuilder.DropIndex(
                name: "IX_studentSubjects_StuId",
                table: "studentSubjects");

            migrationBuilder.DropPrimaryKey(
                name: "PK_departmentSubjects",
                table: "departmentSubjects");

            migrationBuilder.DropIndex(
                name: "IX_departmentSubjects_SubjId",
                table: "departmentSubjects");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "studentSubjects");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "departmentSubjects");

            migrationBuilder.AddColumn<int>(
                name: "InsMangerId",
                table: "departments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_studentSubjects",
                table: "studentSubjects",
                columns: new[] { "StuId", "SubId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_departmentSubjects",
                table: "departmentSubjects",
                columns: new[] { "SubjId", "DepId" });

            migrationBuilder.CreateTable(
                name: "instructors",
                columns: table => new
                {
                    InsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ENameAr = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ENameEn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Position = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SupervisorId = table.Column<int>(type: "int", nullable: false),
                    Salary = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_instructors", x => x.InsId);
                    table.ForeignKey(
                        name: "FK_instructors_departments_DID",
                        column: x => x.DID,
                        principalTable: "departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_instructors_instructors_SupervisorId",
                        column: x => x.SupervisorId,
                        principalTable: "instructors",
                        principalColumn: "InsId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "instructorSubjects",
                columns: table => new
                {
                    InsId = table.Column<int>(type: "int", nullable: false),
                    SubId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_instructorSubjects", x => new { x.InsId, x.SubId });
                    table.ForeignKey(
                        name: "FK_instructorSubjects_instructors_InsId",
                        column: x => x.InsId,
                        principalTable: "instructors",
                        principalColumn: "InsId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_instructorSubjects_subjects_SubId",
                        column: x => x.SubId,
                        principalTable: "subjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_departments_InsMangerId",
                table: "departments",
                column: "InsMangerId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_instructors_DID",
                table: "instructors",
                column: "DID");

            migrationBuilder.CreateIndex(
                name: "IX_instructors_SupervisorId",
                table: "instructors",
                column: "SupervisorId");

            migrationBuilder.CreateIndex(
                name: "IX_instructorSubjects_SubId",
                table: "instructorSubjects",
                column: "SubId");

            migrationBuilder.AddForeignKey(
                name: "FK_departments_instructors_InsMangerId",
                table: "departments",
                column: "InsMangerId",
                principalTable: "instructors",
                principalColumn: "InsId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_departments_instructors_InsMangerId",
                table: "departments");

            migrationBuilder.DropTable(
                name: "instructorSubjects");

            migrationBuilder.DropTable(
                name: "instructors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_studentSubjects",
                table: "studentSubjects");

            migrationBuilder.DropPrimaryKey(
                name: "PK_departmentSubjects",
                table: "departmentSubjects");

            migrationBuilder.DropIndex(
                name: "IX_departments_InsMangerId",
                table: "departments");

            migrationBuilder.DropColumn(
                name: "InsMangerId",
                table: "departments");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "studentSubjects",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "departmentSubjects",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_studentSubjects",
                table: "studentSubjects",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_departmentSubjects",
                table: "departmentSubjects",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_studentSubjects_StuId",
                table: "studentSubjects",
                column: "StuId");

            migrationBuilder.CreateIndex(
                name: "IX_departmentSubjects_SubjId",
                table: "departmentSubjects",
                column: "SubjId");
        }
    }
}
