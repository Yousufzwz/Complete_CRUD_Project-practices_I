using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FirstDemo.Web.Migrations
{
    /// <inheritdoc />
    public partial class CreateCourseEnrollments : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: new Guid("6e07762a-c636-404f-bb8f-eef11dce0d21"));

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: new Guid("927ed339-165d-482b-8016-420a2b10d687"));

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CGPA = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CourseEnrollment",
                columns: table => new
                {
                    CourseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StudentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EnrollmentDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseEnrollment", x => new { x.CourseId, x.StudentId });
                    table.ForeignKey(
                        name: "FK_CourseEnrollment_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseEnrollment_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "Description", "Fees", "Title" },
                values: new object[,]
                {
                    { new Guid("2af83630-863e-4283-966d-3dea4ebc9b16"), "Test", 3000L, "Demo Course 1" },
                    { new Guid("fd5cb08f-ee2e-4388-a61b-0a1af1eaef06"), "Test", 4000L, "Demo Course 2" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CourseEnrollment_StudentId",
                table: "CourseEnrollment",
                column: "StudentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CourseEnrollment");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: new Guid("2af83630-863e-4283-966d-3dea4ebc9b16"));

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: new Guid("fd5cb08f-ee2e-4388-a61b-0a1af1eaef06"));

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "Description", "Fees", "Title" },
                values: new object[,]
                {
                    { new Guid("6e07762a-c636-404f-bb8f-eef11dce0d21"), "Test", 4000L, "Demo Course 2" },
                    { new Guid("927ed339-165d-482b-8016-420a2b10d687"), "Test", 3000L, "Demo Course 1" }
                });
        }
    }
}
