using Microsoft.AspNetCore.Mvc;

namespace GeeksProject02.Controllers
{
    public class GuiController : Controller
    {
        public IActionResult GuiView()
        {
            return View();
        }
    }
}
