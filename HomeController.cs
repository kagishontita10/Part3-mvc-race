using Microsoft.AspNetCore.Mvc;
using part3_mvc_consume.Services;

namespace part3_mvc_consume.Controllers
{
    public class HomeController : Controller
    {

        private readonly ApiServices_events _events;
        public HomeController(ApiServices_events events) { _events = events; }
        public async Task<IActionResult> Index() { ViewBag.Message = await _events.get_events(); return View(); }
        public IActionResult Error() => View();
    }

        
            
        }
    

