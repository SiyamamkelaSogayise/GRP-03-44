using Microsoft.AspNetCore.Mvc;

namespace GeeksProject02.Controllers
{
    public class HomeBookController : Controller
    {
        public IActionResult HomeB()
        {
            return View();
        }
    }
}
