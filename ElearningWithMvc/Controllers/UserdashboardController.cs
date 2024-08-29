using Microsoft.AspNetCore.Mvc;

namespace ElearningWithMvc.Controllers
{
	public class UserdashboardController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
