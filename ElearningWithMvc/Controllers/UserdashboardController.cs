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
			return View();
		}

		public IActionResult About()
		{
			return View();
		}

		public IActionResult Cart()
		{
			return View();
		}

		public IActionResult Details()
		{
			return View();
		}
	}
}
