using ElearningWithMvc.Context;
using ElearningWithMvc.Migrations;
using ElearningWithMvc.Models;
using Microsoft.AspNetCore.Mvc;

namespace ElearningWithMvc.Controllers
{
	
	public class AdminController : Controller
	{
		private readonly IWebHostEnvironment env;
		private readonly ApplicationDbContext db;
		public AdminController(ApplicationDbContext db, IWebHostEnvironment env)
		{
			this.db = db;
			this.env = env;
		}
			public IActionResult Index()
		{
			return View();
		}

		public IActionResult AddCourse ()
		{
			return View();
		}
		[HttpPost]
		public IActionResult AddCourse(AddCourseViewModel a)
		{
			var path = env.WebRootPath;
			var filepath = "/Content/Images" + a.CourseImage.FileName;
			var fullpath = Path.Combine(path+filepath);
			UploadFile(a.CourseImage, fullpath);
			AddCourse obj = new AddCourse()
			{
				CourseName = a.CourseName,
				InstructorName = a.InstructorName,
				Descripation = a.Descripation,
				Price = a.Price,
				Day = a.Day,
				Level = a.Level,
				CourseImage = filepath
			};
			db.AddCourses.Add(obj);
			db.SaveChanges();
			TempData["Course"] = "Course Added Successfully ";
			return RedirectToAction("AddCourse");
		}

		public void UploadFile(IFormFile file, string fullpath)
		{
			FileStream stream = new FileStream(fullpath, FileMode.Create);
			file.CopyTo(stream);
		}

		public IActionResult UserList(Auth a)
		{
			var data = db.User.ToList();
			return View(data);
		}

	}
}
