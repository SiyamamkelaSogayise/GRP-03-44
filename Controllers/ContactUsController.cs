using Microsoft.AspNetCore.Mvc;

namespace GeeksProject02.Controllers
{
    public class ContactUsController : Controller
    {
        public IActionResult ContactUs()
        {
            return View();
        }
    }
}
