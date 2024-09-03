using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ElearningWithMvc.Migrations
{
    /// <inheritdoc />
    public partial class t : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AddToCart");

            migrationBuilder.AddColumn<string>(
                name: "SubCourseImage",
                table: "AddSubCourse",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SubCourseImage",
                table: "AddSubCourse");

            migrationBuilder.CreateTable(
                name: "AddToCart",
                columns: table => new
                {
                    CartId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseId = table.Column<int>(type: "int", nullable: false),
                    CourseImage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CourseName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InstructorName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: true),
                    SubCourse = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Suser = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VideoTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VideoUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AddToCart", x => x.CartId);
                });
        }
    }
}
