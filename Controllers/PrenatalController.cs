using Microsoft.AspNetCore.Mvc;
using GeeksProject02.Models;
using System.Globalization;
using Microsoft.EntityFrameworkCore;
using GeeksProject02.Data;
using System.Security.Claims;

namespace GeeksProject02.Controllers
{
    public class PrenatalController : Controller
    {
        private readonly GeeksProject02Context dbContext;
        public PrenatalController(GeeksProject02Context dBD)
        {
            dbContext = dBD;
        }
        public IActionResult Index(Pregnancy_Tracker tracker)
        {
            //var userID = User.FindFirstValue(ClaimTypes.NameIdentifier);

            //string query = @"SELECT *
            //                 FROM Preg_Stats
            //                 WHERE progress_ID = Preg_Stats.progress_ID";

            //if(tracker.patient_ID == default)
            //{
            //    return View("PregTracker");
            //}
            //else
            //{
            //    return View();
            //}
            return View();
        }
        public IActionResult CheckUps()
        {
            return View();
        }
        public IActionResult PersonalInfo()
        {
            return View();
        }
        public IActionResult PregTracker()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult PregTracker(Pregnancy_Tracker tracker)
        {
            if (ModelState.IsValid)
            {
                dbContext.Pregnancy_Tracker.Add(tracker);
                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tracker);
        }
        ////Get Method which returns the Create.cshtml
        //public IActionResult Create()
        //{
        //    return View();
        //}
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        ////public IActionResult Create(SuperVillains1 villa)
        ////{
        ////    if (ModelState.IsValid)
        ////    {
        ////        dbContext.SuperVillians.Add(villa);
        ////        dbContext.SaveChanges();
        ////        return RedirectToAction("Index");
        ////    }
        ////    return View(villa);
        //}
        ////POST-Create
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult Create(Fighters fighters)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Fighters.Add(fighters);
        //        _context.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(fighters);
        //}

        public IActionResult GetDetails()
        {
            return View();
        }
    }
}
