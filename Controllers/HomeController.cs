using GeeksProject02.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace GeeksProject02.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            if (User.IsInRole("Admin"))
            {
                // Redirect the administrator to the admin landing page
                return RedirectToAction("Index", "Last");
            }
            else if (User.IsInRole("Doctor"))
            {
                return RedirectToAction("Name of doctor method", "name of controller");
            }

            // For other users, show the default landing page
            return RedirectToAction("Index_dash");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        
        public IActionResult Index_dash()
        {
            return View();
        }
        
       
    }
}