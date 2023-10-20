using Microsoft.AspNetCore.Mvc;
using GeeksProject02.Models;

namespace GeeksProject02.Controllers
{
    public class PrenatalController : Controller
    {
        public IActionResult Index(Pregnancy_Tracker tracker)
        {
            if(tracker.last_period == default)
            {
                return View("PregTracker");
            }
            else
            {
                return View();
            }
        }
        public IActionResult CheckUps()
        {
            return View();
        }
        public IActionResult PersonalInfo()
        {
            return View();
        }
        public IActionResult FeedBack()
        {
            return View();
        }
        public IActionResult PregTracker()
        {
            return View();
        }
        ////Get Method which returns the Create.cshtml
        //public IActionResult Create()
        //{
        //    return View();
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
    }
}
