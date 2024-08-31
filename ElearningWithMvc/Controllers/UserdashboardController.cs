using Microsoft.AspNetCore.Mvc;

namespace ElearningWithMvc.Controllers
{
	public class UserdashboardController : Controller
	{
		public IActionResult Index()
		{
			return View();
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
	}
}
