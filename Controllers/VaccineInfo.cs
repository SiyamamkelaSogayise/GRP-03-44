using Microsoft.AspNetCore.Mvc;

namespace GeeksProject02.Controllers
{
    public class VaccineInfo : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult COVID19()
        {
            return View();
        }
    }
}
