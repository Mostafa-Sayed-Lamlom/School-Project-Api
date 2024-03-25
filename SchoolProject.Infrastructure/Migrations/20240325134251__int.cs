using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolProject.Infrastructure.Migrations
{
	/// <inheritdoc />
	public partial class _int : Migration
	{
		/// <inheritdoc />
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.CreateTable(
				name: "AspNetRoles",
				columns: table => new
				{
					Id = table.Column<int>(type: "int", nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
					NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
					ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_AspNetRoles", x => x.Id);
				});

			migrationBuilder.CreateTable(
				name: "AspNetUsers",
				columns: table => new
				{
					Id = table.Column<int>(type: "int", nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
					Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
					Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
					Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
					UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
					NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
					Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
					NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
					EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
					PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
					SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
					ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
					PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
					PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
					TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
					LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
					LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
					AccessFailedCount = table.Column<int>(type: "int", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_AspNetUsers", x => x.Id);
				});

			migrationBuilder.CreateTable(
				name: "subjects",
				columns: table => new
				{
					Id = table.Column<int>(type: "int", nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					Name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
					NameAr = table.Column<string>(type: "nvarchar(max)", nullable: true),
					Period = table.Column<int>(type: "int", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_subjects", x => x.Id);
				});


			migrationBuilder.CreateTable(
				name: "AspNetRoleClaims",
				columns: table => new
				{
					Id = table.Column<int>(type: "int", nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					RoleId = table.Column<int>(type: "int", nullable: false),
					ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
					ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
					table.ForeignKey(
						name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
						column: x => x.RoleId,
						principalTable: "AspNetRoles",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateTable(
				name: "AspNetUserClaims",
				columns: table => new
				{
					Id = table.Column<int>(type: "int", nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					UserId = table.Column<int>(type: "int", nullable: false),
					ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
					ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
					table.ForeignKey(
						name: "FK_AspNetUserClaims_AspNetUsers_UserId",
						column: x => x.UserId,
						principalTable: "AspNetUsers",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateTable(
				name: "AspNetUserLogins",
				columns: table => new
				{
					LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
					ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
					ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
					UserId = table.Column<int>(type: "int", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
					table.ForeignKey(
						name: "FK_AspNetUserLogins_AspNetUsers_UserId",
						column: x => x.UserId,
						principalTable: "AspNetUsers",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateTable(
				name: "AspNetUserRoles",
				columns: table => new
				{
					UserId = table.Column<int>(type: "int", nullable: false),
					RoleId = table.Column<int>(type: "int", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
					table.ForeignKey(
						name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
						column: x => x.RoleId,
						principalTable: "AspNetRoles",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
					table.ForeignKey(
						name: "FK_AspNetUserRoles_AspNetUsers_UserId",
						column: x => x.UserId,
						principalTable: "AspNetUsers",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateTable(
				name: "AspNetUserTokens",
				columns: table => new
				{
					UserId = table.Column<int>(type: "int", nullable: false),
					LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
					Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
					Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
					table.ForeignKey(
						name: "FK_AspNetUserTokens_AspNetUsers_UserId",
						column: x => x.UserId,
						principalTable: "AspNetUsers",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateTable(
				name: "UserRefreshToken",
				columns: table => new
				{
					Id = table.Column<int>(type: "int", nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					UserId = table.Column<int>(type: "int", nullable: false),
					Token = table.Column<string>(type: "nvarchar(max)", nullable: true),
					RefreshToken = table.Column<string>(type: "nvarchar(max)", nullable: true),
					JwtId = table.Column<string>(type: "nvarchar(max)", nullable: true),
					IsUsed = table.Column<bool>(type: "bit", nullable: false),
					IsRevoked = table.Column<bool>(type: "bit", nullable: false),
					AddedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
					ExpiryDate = table.Column<DateTime>(type: "datetime2", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_UserRefreshToken", x => x.Id);
					table.ForeignKey(
						name: "FK_UserRefreshToken_AspNetUsers_UserId",
						column: x => x.UserId,
						principalTable: "AspNetUsers",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateTable(
				name: "departments",
				columns: table => new
				{
					Id = table.Column<int>(type: "int", nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					Name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
					NameAr = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
					InsMangerId = table.Column<int>(type: "int", nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_departments", x => x.Id);
				});

			migrationBuilder.CreateTable(
				name: "departmentSubjects",
				columns: table => new
				{
					DepId = table.Column<int>(type: "int", nullable: false),
					SubjId = table.Column<int>(type: "int", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_departmentSubjects", x => new { x.SubjId, x.DepId });
					table.ForeignKey(
						name: "FK_departmentSubjects_departments_DepId",
						column: x => x.DepId,
						principalTable: "departments",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
					table.ForeignKey(
						name: "FK_departmentSubjects_subjects_SubjId",
						column: x => x.SubjId,
						principalTable: "subjects",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateTable(
				name: "instructors",
				columns: table => new
				{
					InsId = table.Column<int>(type: "int", nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					ENameAr = table.Column<string>(type: "nvarchar(max)", nullable: true),
					ENameEn = table.Column<string>(type: "nvarchar(max)", nullable: true),
					Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
					Position = table.Column<string>(type: "nvarchar(max)", nullable: true),
					SupervisorId = table.Column<int>(type: "int", nullable: true),
					Salary = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
					Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
				name: "students",
				columns: table => new
				{
					Id = table.Column<int>(type: "int", nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
					NameAr = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
					Address = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
					AddressAr = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
					Phone = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
					DId = table.Column<int>(type: "int", nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_students", x => x.Id);
					table.ForeignKey(
						name: "FK_students_departments_DId",
						column: x => x.DId,
						principalTable: "departments",
						principalColumn: "Id");
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

			migrationBuilder.CreateTable(
				name: "studentSubjects",
				columns: table => new
				{
					StuId = table.Column<int>(type: "int", nullable: false),
					SubId = table.Column<int>(type: "int", nullable: false),
					grade = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_studentSubjects", x => new { x.StuId, x.SubId });
					table.ForeignKey(
						name: "FK_studentSubjects_students_StuId",
						column: x => x.StuId,
						principalTable: "students",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
					table.ForeignKey(
						name: "FK_studentSubjects_subjects_SubId",
						column: x => x.SubId,
						principalTable: "subjects",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateIndex(
				name: "IX_AspNetRoleClaims_RoleId",
				table: "AspNetRoleClaims",
				column: "RoleId");

			migrationBuilder.CreateIndex(
				name: "RoleNameIndex",
				table: "AspNetRoles",
				column: "NormalizedName",
				unique: true,
				filter: "[NormalizedName] IS NOT NULL");

			migrationBuilder.CreateIndex(
				name: "IX_AspNetUserClaims_UserId",
				table: "AspNetUserClaims",
				column: "UserId");

			migrationBuilder.CreateIndex(
				name: "IX_AspNetUserLogins_UserId",
				table: "AspNetUserLogins",
				column: "UserId");

			migrationBuilder.CreateIndex(
				name: "IX_AspNetUserRoles_RoleId",
				table: "AspNetUserRoles",
				column: "RoleId");

			migrationBuilder.CreateIndex(
				name: "EmailIndex",
				table: "AspNetUsers",
				column: "NormalizedEmail");

			migrationBuilder.CreateIndex(
				name: "UserNameIndex",
				table: "AspNetUsers",
				column: "NormalizedUserName",
				unique: true,
				filter: "[NormalizedUserName] IS NOT NULL");

			migrationBuilder.CreateIndex(
				name: "IX_departments_InsMangerId",
				table: "departments",
				column: "InsMangerId",
				unique: true,
				filter: "[InsMangerId] IS NOT NULL");

			migrationBuilder.CreateIndex(
				name: "IX_departmentSubjects_DepId",
				table: "departmentSubjects",
				column: "DepId");

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

			migrationBuilder.CreateIndex(
				name: "IX_students_DId",
				table: "students",
				column: "DId");

			migrationBuilder.CreateIndex(
				name: "IX_studentSubjects_SubId",
				table: "studentSubjects",
				column: "SubId");

			migrationBuilder.CreateIndex(
				name: "IX_UserRefreshToken_UserId",
				table: "UserRefreshToken",
				column: "UserId");

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
				name: "AspNetRoleClaims");

			migrationBuilder.DropTable(
				name: "AspNetUserClaims");

			migrationBuilder.DropTable(
				name: "AspNetUserLogins");

			migrationBuilder.DropTable(
				name: "AspNetUserRoles");

			migrationBuilder.DropTable(
				name: "AspNetUserTokens");

			migrationBuilder.DropTable(
				name: "departmentSubjects");

			migrationBuilder.DropTable(
				name: "instructorSubjects");

			migrationBuilder.DropTable(
				name: "studentSubjects");

			migrationBuilder.DropTable(
				name: "UserRefreshToken");


			migrationBuilder.DropTable(
				name: "AspNetRoles");

			migrationBuilder.DropTable(
				name: "students");

			migrationBuilder.DropTable(
				name: "subjects");

			migrationBuilder.DropTable(
				name: "AspNetUsers");

			migrationBuilder.DropTable(
				name: "instructors");

			migrationBuilder.DropTable(
				name: "departments");
		}
	}
}
