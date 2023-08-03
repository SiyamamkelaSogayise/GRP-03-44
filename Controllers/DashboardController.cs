using Microsoft.AspNetCore.Mvc;

namespace GeeksProject02.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
