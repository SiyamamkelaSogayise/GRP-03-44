using Microsoft.AspNetCore.Mvc;

namespace GeeksProject02.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        private static List<Booking> bookings = new List<Booking>
        {
            new Booking { Id = 1, Username = "user1", Password = "password1", AppointmentDate = DateTime.Now, Preference = "weekday", ForDependent = false },
            new Booking { Id = 2, Username = "user2", Password = "password2", AppointmentDate = DateTime.Now.AddDays(1), Preference = "weekend", ForDependent = true }
        };

        public ActionResult AdminPage()
        {
            return View(bookings);
        }
    }
}
