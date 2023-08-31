using Microsoft.AspNetCore.Mvc;

namespace GeeksProject02.Controllers
{
    public class CounsellingController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
