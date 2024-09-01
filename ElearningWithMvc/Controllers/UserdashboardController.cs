using ElearningWithMvc.Context;
using ElearningWithMvc.Migrations;
using ElearningWithMvc.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static ElearningWithMvc.Models.AllCourse;

namespace ElearningWithMvc.Controllers
{
	public class UserdashboardController : Controller
	{
		private readonly ApplicationDbContext db;
		public UserdashboardController(ApplicationDbContext db) 
		{
			this.db = db;
		}

		public IActionResult Index()
		{
			var topCourses = db.AddCourses.OrderBy(c => c.CourseId).Take(5).ToList();
			return View(topCourses);
			
		}

		public IActionResult Userhome()
		{
			return View();
		}

		public IActionResult AllCourse()
		{
            var topCourses = db.AddCourses.ToList();
            return View(topCourses);
           
		}

		public IActionResult About()
		{
			return View();
		}


        //public IActionResult AddToCart()
        //{
        //    return View();
        //}

        [HttpPost]
        public IActionResult Cart(AddToCart model, List<string> SubCourse, List<string> VideoTitle, List<string> VideoUrl)
        {
            if (ModelState.IsValid)
            {
               var user = HttpContext.Session.GetString("Username");
               
                for (int i = 0; i < SubCourse.Count; i++)
                {
                    var cartItem = new AddToCart
                    {
                        CourseId = model.CourseId,
                        CourseName = model.CourseName,
                        InstructorName = model.InstructorName,
                        CourseImage = model.CourseImage,
                        Price = model.Price,
                        Suser = user,
                        SubCourse = SubCourse[i],
                        VideoTitle = VideoTitle[i],
                        VideoUrl = VideoUrl[i], 
                        Quantity = model.Quantity 
                    };

                    db.AddToCart.Add(cartItem);
                }

                db.SaveChanges();

                
                //return RedirectToAction("Cart");
            }

         
            return View(model);
        }


        public IActionResult Details(int id)
		{
            var course = db.AddCourses.Find(id);
            if (course == null)
            {
                return NotFound();
            }

            var courseVideos = db.AddSubCourse.Where(v => v.Coursename == course.CourseName).ToList();

            var viewModel = new AllCourse
            {
                Course = course,
                AddSubCourse = courseVideos
            };

            return View(viewModel);
        }

		

		public IActionResult SubCourseList(string CourseName)
		{
            var courses = db.AddCourses.Where(x=>x.CourseName == CourseName).ToList();
            if (courses == null || !courses.Any())
            {
                return NotFound();
            }

            var courseVideos = db.AddSubCourse.Where(v => v.Coursename == CourseName).ToList();

            var viewModel = new AllCourse
            {
                Course = courses.FirstOrDefault(),
                AddSubCourse = courseVideos
            };

            return View(viewModel); 
		}

		
	}
}
