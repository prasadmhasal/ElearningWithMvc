using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ElearningWithMvc.Migrations
{
    /// <inheritdoc />
    public partial class AddSubCourse : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AddSubCourse",
                columns: table => new
                {
                    CourseVideoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Coursename = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Subcourse = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VideoTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VideoUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AddSubCourse", x => x.CourseVideoId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AddSubCourse");
        }
    }
}
