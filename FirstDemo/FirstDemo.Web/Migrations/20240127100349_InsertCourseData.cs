using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FirstDemo.Web.Migrations
{
    /// <inheritdoc />
    public partial class InsertCourseData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "Description", "Fees", "Title" },
                values: new object[,]
                {
                    { new Guid("6e07762a-c636-404f-bb8f-eef11dce0d21"), "Test", 4000L, "Demo Course 2" },
                    { new Guid("927ed339-165d-482b-8016-420a2b10d687"), "Test", 3000L, "Demo Course 1" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: new Guid("6e07762a-c636-404f-bb8f-eef11dce0d21"));

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: new Guid("927ed339-165d-482b-8016-420a2b10d687"));
        }
    }
}
