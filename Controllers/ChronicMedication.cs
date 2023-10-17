using Microsoft.AspNetCore.Mvc;

namespace GeeksProject02.Controllers
{
    public class ChronicMedication : Controller
    {
        public IActionResult Chronic()
        {
            return View();
        }
        public IActionResult MentalHealth()
        {
            return View();
        }
        public IActionResult Exercise()
        {

            return View();
        }
        public IActionResult TakingMeds()
        {
            return View();
        }
    }
}
