using Microsoft.AspNetCore.Mvc;

namespace GeeksProject02.Controllers
{
    public class AdultsNextPageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult AdultsNextPage()
        {
            return View();
        }
    }
}
