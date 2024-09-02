using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ElearningWithMvc.Migrations
{
    /// <inheritdoc />
    public partial class ch : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Coursename",
                table: "AddSubCourse");

            migrationBuilder.DropColumn(
                name: "Day",
                table: "AddCourses");

            migrationBuilder.DropColumn(
                name: "Descripation",
                table: "AddCourses");

            migrationBuilder.DropColumn(
                name: "Level",
                table: "AddCourses");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "AddCourses");

            migrationBuilder.DropColumn(
                name: "Subcoursename",
                table: "AddCourses");

            migrationBuilder.RenameColumn(
                name: "VideoUrl",
                table: "AddSubCourse",
                newName: "Level");

            migrationBuilder.RenameColumn(
                name: "VideoTitle",
                table: "AddSubCourse",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "CourseVideoId",
                table: "AddSubCourse",
                newName: "SubCourseId");

            migrationBuilder.AddColumn<double>(
                name: "price",
                table: "AddSubCourse",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AlterColumn<string>(
                name: "InstructorName",
                table: "AddCourses",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "CourseName",
                table: "AddCourses",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "CourseImage",
                table: "AddCourses",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "price",
                table: "AddSubCourse");

            migrationBuilder.RenameColumn(
                name: "Level",
                table: "AddSubCourse",
                newName: "VideoUrl");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "AddSubCourse",
                newName: "VideoTitle");

            migrationBuilder.RenameColumn(
                name: "SubCourseId",
                table: "AddSubCourse",
                newName: "CourseVideoId");

            migrationBuilder.AddColumn<string>(
                name: "Coursename",
                table: "AddSubCourse",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "InstructorName",
                table: "AddCourses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CourseName",
                table: "AddCourses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CourseImage",
                table: "AddCourses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Day",
                table: "AddCourses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Descripation",
                table: "AddCourses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Level",
                table: "AddCourses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<double>(
                name: "Price",
                table: "AddCourses",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "Subcoursename",
                table: "AddCourses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
