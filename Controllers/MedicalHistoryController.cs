using Microsoft.AspNetCore.Mvc;

namespace GeeksProject02.Controllers
{
    public class MedicalHistoryController : Controller
    {
        public IActionResult MedHistory()
        {
            return View();
        }
    }
}
