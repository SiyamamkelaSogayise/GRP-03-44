using Microsoft.AspNetCore.Mvc;

namespace GeeksProject02.Controllers
{
    public class NewLandingPage : Controller
    {
        public IActionResult LandingPage()
        {
            return View();
        }
        public IActionResult ContactUs() 
        { 
            return View();
        }
    }
}
