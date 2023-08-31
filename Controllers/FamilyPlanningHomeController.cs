using Microsoft.AspNetCore.Mvc;

namespace GeeksProject02.Controllers
{
    public class FamilyPlanningHomeController : Controller
    {
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
