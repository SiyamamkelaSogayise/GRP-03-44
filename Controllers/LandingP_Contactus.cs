using Microsoft.AspNetCore.Mvc;

namespace GeeksProject02.Controllers
{
    public class LandingP_Contactus : Controller
    {
        public IActionResult ContactUs()
        {
            return View();
        }
    }
}
