using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace First_MVC.Migrations
{
    /// <inheritdoc />
    public partial class degINnum : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Trainee",
                columns: new[] { "Id", "Address", "DepartmentId", "Grade", "ImageURL", "Name" },
                values: new object[,]
                {
                    { 1, "123 Trainee St", 1, 60, "1.jpg", "Emily Davis" },
                    { 2, "456 Student Blvd", 2, 50, "2.jpg", "James Miller" },
                    { 3, "789 Study Ave", 3, 40, "3.jpg", "Linda Brown" }
                });
        }
    }
}
