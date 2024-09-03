using ElearningWithMvc.Context;
using ElearningWithMvc.Migrations;
using ElearningWithMvc.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Asn1.X509;
using Razorpay.Api;
using static ElearningWithMvc.Models.AllCourse;

namespace ElearningWithMvc.Controllers
{
	public class UserdashboardController : Controller
	{
		private readonly ApplicationDbContext db;
          private readonly string _keyId = "rzp_test_4DrJJevYZkd0No";
        private readonly string _keySecret = "3oX1Dvxlpy2wB3BGnDPxGtH8";
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


       

        public IActionResult MyCourse()
        {
           var email = HttpContext.Session.GetString("Email");
           var data =  db.AddSubCourse.FromSqlRaw($"exec fetchmycourse '{email}'").ToList();
            foreach (var course in data) 
            { 

            
            }
           return View(data);
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

     
        public IActionResult ByNow(int id)
        {
            var data = db.AddSubCourse.Find(id);
            var amount = data.price;
            ViewBag.totalprice = amount;

             HttpContext.Session.SetInt32("SubcourseId", id);
            var options = new Dictionary<string, object>
            {
                { "amount", amount * 100 },  // Amount in paise
                { "currency", "INR" },
                { "receipt", "order_rcptid_" + DateTime.Now.Ticks },
                { "payment_capture", 1 }
            };

            var client = new RazorpayClient(_keyId, _keySecret);
            var razorpayOrder = client.Order.Create(options);
            ViewBag.razorpayOrder = razorpayOrder["id"];
            ViewBag.Key = _keyId;
            return View("Checkout");
        }
        public IActionResult SubCourseList(int id)
        {
            var courses = db.AddCourses.Where(x => x.CourseId == id).ToList();
            if (courses == null || !courses.Any())
            {
                return NotFound();
            }
            var coursename = courses.First().CourseId;
            //var course = db.AddCourses.Find
            var courseVideos = db.AddSubCourse.Where(v => v.CourseId == coursename).ToList();

            var viewModel = new AllCourse
            {
                Course = courses.ToList(),
                AddSubCourse = courseVideos
            };

            return View(viewModel);
        }

        public IActionResult Successpayment()
        {
            int subcourseId = Convert.ToInt32(HttpContext.Session.GetInt32("SubcourseId").ToString());
            var UserEmail = HttpContext.Session.GetString("Email");
            var data = new PaymentDone
            {
               SubCourseId = subcourseId ,
               UserEmail = UserEmail 
            };
            db.PaymentDone.Add(data);
            db.SaveChanges();
            return RedirectToAction("AllCourse");
        }
    }
}
