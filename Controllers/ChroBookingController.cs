//using Microsoft.AspNetCore.Mvc;
//using GeeksProject02.Data;
//using GeeksProject02.Models;

//namespace GeeksProject02.Controllers
//{
//    public class ChroBookingController : Controller
//    {
//        public readonly GeeksProject02Context dbContext;
//        public ChroBookingController(GeeksProject02Context obj)
//        {
//            dbContext = obj;
//        }
//        public IActionResult Manage()
//        {
//            IEnumerable<ChronicBooking> objList = dbContext.BookingChronic;
//            return View(objList);
//        }
//        public IActionResult Book()
//        {
//            return View();
//        }
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public IActionResult Book(ChronicBooking obj)
//        {
//            if (ModelState.IsValid)
//            {
//                dbContext.BookingChronic.Add(obj);
//                dbContext.SaveChanges();
//                return RedirectToAction("Book");
//            }
//            else
//            {
//                return View();
//            }
//        }

//    }
//}
