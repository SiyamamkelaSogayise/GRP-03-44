using Microsoft.AspNetCore.Mvc;

namespace GeeksProject02.Controllers
{
    public class MedicalAidController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult MedicalAid()
        {
            return View();
        }
    }
}
