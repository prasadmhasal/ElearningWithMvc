using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ElearningWithMvc.Migrations
{
    /// <inheritdoc />
    public partial class subcou : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Subcoursename",
                table: "AddCourses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Subcoursename",
                table: "AddCourses");
        }
    }
}
