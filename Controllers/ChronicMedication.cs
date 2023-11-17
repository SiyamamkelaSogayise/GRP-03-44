using GeeksProject02.Data;
using Microsoft.AspNetCore.Mvc;
using GeeksProject02.Models;

namespace GeeksProject02.Controllers
{
    public class ChronicMedication : Controller
    {
        public readonly GeeksProject02Context _Context;
        public ChronicMedication(GeeksProject02Context obj)
        {
            _Context = obj;
        }
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
        public IActionResult ViewNotes()
        {
            IEnumerable<Notes> objList = _Context.Notes;
            return View(objList);
        }
        public IActionResult Prescription()
        {
            IEnumerable<ChronicPrescription> objList = _Context.ChronicPrescriptions;
            return View(objList);
        }
        public IActionResult FollowUpMeetings()
        {
            IEnumerable<ChronicNextMeeting> objList = _Context.ChronicNextMeeting;
            return View(objList);
        }
        public IActionResult AddMedicalHistory()
        {
            
            return View();
        }
        public IActionResult RequestRefills()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult RequestRefills(Refills c)
        {
            if (ModelState.IsValid)
            {
                _Context.Refills.Add(c);
                _Context.SaveChanges();
                TempData["SuccessMessage"] = "Diagnosis form have been saved Successfully!";
                return RedirectToAction("SaveDiagnosis");
            }
            else
            {
                return View();
            }
        }
    }
}
