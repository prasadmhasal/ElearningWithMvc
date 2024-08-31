using System.ComponentModel.DataAnnotations;

namespace ElearningWithMvc.Models
{
	public class AddCourse
	{
		[Key]
		public int CourseId { get; set; }

		public string CourseName {  get; set; }

		public string InstructorName {  get; set; }

		public string CourseImage { get; set; }

		public string Descripation {  get; set; }
		 
		public double Price { get; set; }

		public string Day { get; set; }

		public string Level { get; set; }

	}
}
