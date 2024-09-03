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
			var filepath = "/Content/Images/" + a.CourseImage.FileName;
			var fullpath = Path.Combine(path+filepath);
			UploadFile(a.CourseImage, fullpath);
			AddCourse obj = new AddCourse()
			{
				CourseName = a.CourseName,	
                InstructorName = a.InstructorName,
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

		[HttpGet]

		public IActionResult GetSubCourse(int data)
		{
			var ab = db.AddSubCourse.Where(x => x.CourseId == data).ToList();
			return Json(ab);

		}

		public IActionResult UploadVideos()
		{
			return View();
		}
		[HttpPost]
        public IActionResult UploadVideos(SubcourseVideo s)
        {
			db.SubcourseVideo.Add(s);
			db.SaveChanges();
            return View();
        }

        public IActionResult AddSubCourse()
        {
            return View();
        }


		[HttpPost]
		public IActionResult AddSubCourse(AddSubcourseViewModel c)
		{

			var path = env.WebRootPath;
			var filepath = "/Content/Images/" + c.SubCourseImage.FileName;
			var fullpath = Path.Combine(path + filepath);
			UploadFile(c.SubCourseImage, fullpath);
            CourseVideo obj = new CourseVideo()
			{
                Subcourse = c.Subcourse,
				Description = c.Description,
				price = c.price,
				Level = c.Level,
				SubCourseImage = fullpath

			};
			db.AddSubCourse.Add(obj);
			db.SaveChanges();
			TempData["SubCourseAdd"] = "You have SubCourse Added Successfully";
			return RedirectToAction("AddSubCourse");

		}

	}
}
