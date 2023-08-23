using Microsoft.AspNetCore.Mvc;

namespace GeeksProject02.Controllers
{
    public class AppointmentPreferenceController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult AppointmentPreference()
        {
            return View();
        }
    }
}
