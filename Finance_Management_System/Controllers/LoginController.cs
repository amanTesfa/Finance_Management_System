using Finance_Management_System.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Finance_Management_System.Controllers
{
    public class LoginController : Controller
    { 
        public class UserDTO
        {
            public string Username { get; set; }
            public string Password { get; set; }
        }

        public ActionResult Index(int i)
        {
            return View();
        }
    }
}
