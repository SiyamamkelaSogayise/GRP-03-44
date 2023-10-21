using Microsoft.AspNetCore.Mvc;

namespace GeeksProject02.Controllers
{
    public class AboutUsController : Controller
    {
        public IActionResult AboutUs()
        {
            return View();
        }
    }
}
