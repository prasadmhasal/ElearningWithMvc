using ElearningWithMvc.Context;
using ElearningWithMvc.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace ElearningWithMvc.Controllers
{
    public class AuthController : Controller
    {
        private readonly ApplicationDbContext db;
        public AuthController(ApplicationDbContext db)
        {
            this.db = db;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult SignIn()
        {
            return View();
        }

        public static string  EncryptPassword(string password)
        {
            if (string.IsNullOrEmpty(password))
            {
                return null;
            }
            else
            {
                byte[] pass = ASCIIEncoding.ASCII.GetBytes(password);
                string encrpass = Convert.ToBase64String(pass);
                return encrpass;
            }

        }

        [HttpPost]
        public IActionResult SignIn(Auth a)
        {
            a.Urole = "User";
            a.Password = EncryptPassword(a.Password);
            db.User.Add(a);
            db.SaveChanges();
            TempData["SignIn"] = "You Have Successfully SignIn ";
            return RedirectToAction("SignIn");
        }


        public IActionResult SignUp()
        {
            return View();
        }

		public static string DecrptPassword(string password)
		{
			if (string.IsNullOrEmpty(password))
			{
				return null;
			}
			else
			{
				byte[] pass = Convert.FromBase64String(password);
				string decrpass = ASCIIEncoding.ASCII.GetString(pass);
				return decrpass;
			}
		}

        [HttpPost]
		public IActionResult SignUp(SignUpViewModel s)
        {
            var data = db.User.Where(x => x.Email.Equals(s.Email)).SingleOrDefault();
            if (data != null)
            {
                bool us = data.Email.Equals(s.Email) && DecrptPassword(data.Password).Equals(s.Password);
                if(us)
                {
                    HttpContext.Session.SetString("Email", data.Email);
                    HttpContext.Session.SetString("Username", data.Username);
                    TempData["Login"] = "login sucessfully";
                    return RedirectToAction("Index", "Dashboard");
                }
                else
                {
                    TempData["Email"] = "Invalid EmailId";
                } 
            }
            else
            {
                TempData["Pass"] = "Invalid Password";

            }
            return View();

        }
        
    }
}
