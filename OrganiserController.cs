using Microsoft.AspNetCore.Mvc;
using part3_mvc_consume.Models;
using part3_mvc_consume.Services;
using Results = part3_mvc_consume.Models.Results;

namespace part3_mvc_consume.Controllers
{
    public class OrganiserController : Controller
    {

        private readonly ApiServices_events _events; private readonly ApiServices_categories _cats; private readonly ApiServices_Enrolments _enrol; private readonly ApiServices_Results _res; private readonly ApiServices_Users _users;
        public OrganiserController(ApiServices_events e, ApiServices_categories c, ApiServices_Enrolments en, ApiServices_Results r, ApiServices_Users u) { _events = e; _cats = c; _enrol = en; _res = r; _users = u; }
        public async Task<IActionResult> Dashboard() { ViewBag.Message = await _events.get_events(); return View(); }
        public async Task<IActionResult> Events() { ViewBag.Message = await _events.get_events(); return View(); }
        public async Task<IActionResult> Details() { ViewBag.Message = await _events.get_events(); ViewBag.Categories = await _cats.get_categories(); ViewBag.Enrolments = await _enrol.get_enrolments(HttpContext.Session.GetString("userID")); ViewBag.Results = await _res.get_results(HttpContext.Session.GetString("userID")); return View(); }
        [HttpGet] public IActionResult Create() { return View(new Events()); }
        [HttpPost] public async Task<IActionResult> Create(Events e) { string m = await _events.store_event(HttpContext.Session.GetString("userID"), e); if (m.Contains("successfully")) return RedirectToAction("Events"); ViewBag.Message = m; return View(e); }
        public async Task<IActionResult> Categories() { ViewBag.Message = await _cats.get_categories(); return View(); }
        [HttpGet] public IActionResult AddCategory() { return View(new categories()); }
        [HttpPost] public async Task<IActionResult> AddCategory(categories c) { string m = await _cats.store_category(HttpContext.Session.GetString("userID"), c); if (m.Contains("successfully")) return RedirectToAction("Categories"); ViewBag.Message = m; return View(c); }
        public async Task<IActionResult> Enrolments() { ViewBag.Message = await _enrol.get_enrolments(HttpContext.Session.GetString("userID")); return View(); }
        public async Task<IActionResult> Results() { ViewBag.Message = await _res.get_results(HttpContext.Session.GetString("userID")); return View(); }
        [HttpGet] public IActionResult AddResult() { return View(new Results()); }
        [HttpPost] public async Task<IActionResult> AddResult(Results r) { string m = await _res.store_result(HttpContext.Session.GetString("userID"), r); if (m.Contains("successfully")) return RedirectToAction("Results"); ViewBag.Message = m; return View(r); }
        [HttpGet] public IActionResult Profile() { return View(new ProfileViewModel()); }
        [HttpPost] public async Task<IActionResult> SaveProfile(ProfileViewModel m) { if (!ModelState.IsValid) return View("Profile", m); string msg = await _users.update_profile(HttpContext.Session.GetString("userID"), m.Name + " " + m.Surname, HttpContext.Session.GetString("email")); TempData["Msg"] = "Profile saved successfully"; return RedirectToAction("Profile"); }
    }
}



