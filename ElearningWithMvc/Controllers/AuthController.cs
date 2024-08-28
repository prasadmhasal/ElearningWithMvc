using Microsoft.AspNetCore.Mvc;

namespace ElearningWithMvc.Controllers
{
    public class AuthController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult SignIn()
        {
            return View();
        }
    }
}
