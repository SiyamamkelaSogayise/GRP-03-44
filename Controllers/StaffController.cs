using Microsoft.AspNetCore.Mvc;

namespace GeeksProject02.Controllers
{
    public class StaffController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
