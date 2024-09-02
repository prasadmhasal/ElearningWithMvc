using System.ComponentModel.DataAnnotations;

namespace ElearningWithMvc.Models
{
	public class AddCourse
	{
		[Key]
		public int CourseId { get; set; }

		public string? CourseName {  get; set; }
		
		

		public string? InstructorName {  get; set; }

		public string? CourseImage { get; set; }

		
		

	}
}
