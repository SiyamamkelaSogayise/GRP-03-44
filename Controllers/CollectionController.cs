using Microsoft.AspNetCore.Mvc;

namespace GeeksProject02.Controllers
{
    public class CollectionController : Controller
    {
        public IActionResult Collect()
        {
            return View();
        }
    }
}
