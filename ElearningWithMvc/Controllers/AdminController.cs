using ElearningWithMvc.Context;
using ElearningWithMvc.Migrations;
using ElearningWithMvc.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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


        public IActionResult ToggleStatus(int id)
        {
            var user = db.User.Find(id);
            if (user == null)
            {
                return NotFound();
            }

            user.Status = user.Status == "Active" ? "Block" : "Active";
            db.User.Update(user);
            db.SaveChanges();
			TempData["ChangeSatus"] = "You have Successfully Change Status";
            return RedirectToAction("UserList");
        }



        [HttpGet]
        public IActionResult CourseNames()
        {
            var courseNames = db.AddCourses.FromSqlRaw($" exec FetchCoursesAll").ToList();
			 
            return Json(courseNames);
        }

  
        public IActionResult AddSubCourse()
        {
            return View();
        }


		[HttpPost]
		public IActionResult AddSubCourse(CourseVideo c)
		{
			db.AddSubCourse.Add(c);
			db.SaveChanges();
			TempData["SubCourseAdd"] = "You have SubCourse Added Successfully";
			return RedirectToAction("AddSubCourse");

		}

    }
}
