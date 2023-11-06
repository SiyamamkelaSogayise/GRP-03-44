using Microsoft.AspNetCore.Mvc;

namespace GeeksProject02.Controllers
{
    public class FamilyPlanningAdminController : Controller
    {
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
    }
}
