using GeeksProject02.Models;
using Microsoft.AspNetCore.Mvc;

namespace GeeksProject02.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Vaccine()
        {
            return View();
        }

        //[HttpPost]
        //public IActionResult Vaccine()
        //{
        //    return RedirectToAction("Index");
        //}
    } 
}

