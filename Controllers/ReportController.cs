using Microsoft.AspNetCore.Mvc;

namespace GeeksProject02.Controllers
{
    public class ReportController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
