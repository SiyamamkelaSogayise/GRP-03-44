using Microsoft.AspNetCore.Mvc;

namespace GeeksProject02.Controllers
{
    public class ServicesController : Controller
    {
        public IActionResult Services()
        {
            return View();
        }
    }
}
