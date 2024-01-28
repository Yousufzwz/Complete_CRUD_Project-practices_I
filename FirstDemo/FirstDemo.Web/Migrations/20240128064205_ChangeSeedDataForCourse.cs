using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FirstDemo.Web.Migrations
{
    /// <inheritdoc />
    public partial class ChangeSeedDataForCourse : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseEnrollment_Courses_CourseId",
                table: "CourseEnrollment");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseEnrollment_Students_StudentId",
                table: "CourseEnrollment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CourseEnrollment",
                table: "CourseEnrollment");

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: new Guid("2af83630-863e-4283-966d-3dea4ebc9b16"));

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: new Guid("fd5cb08f-ee2e-4388-a61b-0a1af1eaef06"));

            migrationBuilder.RenameTable(
                name: "CourseEnrollment",
                newName: "CourseEnrollments");

            migrationBuilder.RenameIndex(
                name: "IX_CourseEnrollment_StudentId",
                table: "CourseEnrollments",
                newName: "IX_CourseEnrollments_StudentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CourseEnrollments",
                table: "CourseEnrollments",
                columns: new[] { "CourseId", "StudentId" });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "Description", "Fees", "Title" },
                values: new object[,]
                {
                    { new Guid("6e07762a-c636-404f-bb8f-eef11dce0d21"), "Test", 3000L, "Demo Course 1" },
                    { new Guid("927ed339-165d-482b-8016-420a2b10d687"), "Test", 4000L, "Demo Course 2" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_CourseEnrollments_Courses_CourseId",
                table: "CourseEnrollments",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseEnrollments_Students_StudentId",
                table: "CourseEnrollments",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseEnrollments_Courses_CourseId",
                table: "CourseEnrollments");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseEnrollments_Students_StudentId",
                table: "CourseEnrollments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CourseEnrollments",
                table: "CourseEnrollments");

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: new Guid("6e07762a-c636-404f-bb8f-eef11dce0d21"));

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: new Guid("927ed339-165d-482b-8016-420a2b10d687"));

            migrationBuilder.RenameTable(
                name: "CourseEnrollments",
                newName: "CourseEnrollment");

            migrationBuilder.RenameIndex(
                name: "IX_CourseEnrollments_StudentId",
                table: "CourseEnrollment",
                newName: "IX_CourseEnrollment_StudentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CourseEnrollment",
                table: "CourseEnrollment",
                columns: new[] { "CourseId", "StudentId" });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "Description", "Fees", "Title" },
                values: new object[,]
                {
                    { new Guid("2af83630-863e-4283-966d-3dea4ebc9b16"), "Test", 3000L, "Demo Course 1" },
                    { new Guid("fd5cb08f-ee2e-4388-a61b-0a1af1eaef06"), "Test", 4000L, "Demo Course 2" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_CourseEnrollment_Courses_CourseId",
                table: "CourseEnrollment",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseEnrollment_Students_StudentId",
                table: "CourseEnrollment",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
