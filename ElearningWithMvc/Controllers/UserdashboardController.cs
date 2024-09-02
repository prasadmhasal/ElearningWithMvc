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

       
        


       

        //[HttpPost]
        //public IActionResult Cart(int[] id , AddToCart a)
        //{
            
        //       var user = HttpContext.Session.GetString("Username");
               
        //        foreach (var b in id)
        //        {
        //            var cartItem = new AddToCart
        //            {
        //                CourseId = id,
        //                CourseName = id.CourseName,
        //                InstructorName = model.InstructorName,
        //                CourseImage = model.CourseImage,
        //                Price = model.Price,
        //                Suser = user,
        //                SubCourse = SubCourse[i],
        //                VideoTitle = VideoTitle[i],
        //                VideoUrl = VideoUrl[i], 
        //                Quantity = model.Quantity 
        //            };

        //            db.AddToCart.Add(cartItem);
        //        }

        //        db.SaveChanges();

                
               

         
        //    return View(model);
        //}


  //      public IActionResult Details(int id)
		//{
  //          var course = db.AddCourses.Find(id);
  //          if (course == null)
  //          {
  //              return NotFound();
  //          }

  //          var courseVideos = db.AddSubCourse.Where(v => v.Coursename == course.CourseName).ToList();

  //          var viewModel = new AllCourse
  //          {
  //              Course = course,
  //              AddSubCourse = courseVideos
  //          };

  //          return View(viewModel);
  //      }

		

		public IActionResult SubCourseList(int id)
		{
            var courses = db.AddCourses.Where(x=>x.CourseId == id);
            if (courses == null || !courses.Any())
            {
                return NotFound();
            }
            var coursename=courses.First().CourseName;
            //var course = db.AddCourses.Find
            var courseVideos = db.AddSubCourse.Where(v => v.Coursename == coursename).ToList();

            var viewModel = new AllCourse
            {
                Course = courses.ToList(),
                AddSubCourse = courseVideos
            };

            return View(viewModel); 
		}

		
	}
}
