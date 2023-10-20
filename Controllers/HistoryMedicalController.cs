using GeeksProject02.Data;
using GeeksProject02.Models;
using Microsoft.AspNetCore.Mvc;

namespace GeeksProject02.Controllers
{
    public class HistoryMedicalController : Controller
    {
        public readonly GeeksProject02Context dbContext;
        public HistoryMedicalController(GeeksProject02Context obj)
        {
            dbContext = obj;
        }

        public IActionResult ViewMedicalHistory()
        {
            IEnumerable<MedicalHistory> objList = dbContext.ChronicMedicalHistory;
            return View(objList);
        }
        public IActionResult SubmittDetails()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SubmittDetails(MedicalHistory obj)
        {
            if (ModelState.IsValid)
            {
                dbContext.ChronicMedicalHistory.Add(obj);
                dbContext.SaveChanges();
                TempData["AlertMessage"] = "Medical History Form completed successfully!";
                return RedirectToAction("SubmittDetails");
            }
            else
            {
                return View();

            }
        } }   }  

