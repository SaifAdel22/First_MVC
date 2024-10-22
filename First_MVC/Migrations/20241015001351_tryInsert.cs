using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace First_MVC.Migrations
{
    /// <inheritdoc />
    public partial class tryInsert : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Trainee",
                columns: new[] { "Id", "Address", "DepartmentId", "Grade", "ImageURL", "Name" },
                values: new object[,]
                {
                    { 4, "101 Trainee Ln", 1, 30, "4.jpg", "Michael Johnson" },
                    { 5, "202 Learning Rd", 2, 60, "5.jpg", "Sophia Williams" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Trainee",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Trainee",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
