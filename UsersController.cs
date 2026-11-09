using Microsoft.AspNetCore.Mvc;
using part3_mvc_consume.Services;
using part3_mvc_consume.Models;

namespace part3_mvc_consume.Controllers
{
    public class UsersController : Controller
    {
        private readonly ApiServices_Users _api;
        public UsersController(ApiServices_Users api) { _api = api; }

        [HttpGet]
        public IActionResult Register() { return View(); }

        [HttpPost]
        public async Task<IActionResult> Register(Users user)
        {
            string m = await _api.store_user(user);
            ViewBag.Message = "API SAYS: " + m + $" | You sent: Name={user.fullName} Email={user.email} PassLen={user.password?.Length} Role={user.role}";
            if (m.Contains("successfully", StringComparison.OrdinalIgnoreCase))
                return RedirectToAction("Login");
            return View(user);
        }

        [HttpGet]
        public IActionResult Login() { return View(); }

        [HttpPost]
        public async Task<IActionResult> Login(string email, string password)
        {
            string m = await _api.login_user(email, password);
            if (m.Contains("Login Successfull"))
            {
                string userID = m.Split(' ')[0];
                HttpContext.Session.SetString("userID", userID);
                HttpContext.Session.SetString("email", email);
                if (m.Contains("organiser")) return RedirectToAction("Dashboard", "Organiser");
                return RedirectToAction("Dashboard", "Participant");
            }
            ViewBag.Message = m;
            return View();
        }
    }
}
