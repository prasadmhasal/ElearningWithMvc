using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ElearningWithMvc.Migrations
{
    /// <inheritdoc />
    public partial class adddddd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CourseId",
                table: "AddSubCourse",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CourseId",
                table: "AddSubCourse");
        }
    }
}
