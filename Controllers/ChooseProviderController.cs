using Microsoft.AspNetCore.Mvc;

namespace GeeksProject02.Controllers
{
    public class ChooseProviderController : Controller
    {
        public IActionResult ChooseProvider()
        {
            return View();
        }
    }
}
