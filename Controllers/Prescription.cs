using Microsoft.AspNetCore.Mvc;

namespace GeeksProject02.Controllers
{
    public class Prescription : Controller
    {
        public IActionResult Self()
        {
            return View();
        }
    }
}
