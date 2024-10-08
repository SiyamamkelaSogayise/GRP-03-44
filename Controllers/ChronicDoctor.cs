﻿using Microsoft.AspNetCore.Mvc;
using GeeksProject02.Data;
using GeeksProject02.Models; 

namespace GeeksProject02.Controllers
{
    public class ChronicDoctor : Controller
    {
        public readonly GeeksProject02Context _Context;
        public ChronicDoctor(GeeksProject02Context obj)
        {
            _Context = obj;
        }
        public IActionResult Doctor()
        {
            return View();
        }

        public IActionResult SaveDiagnosis()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SaveDiagnosis(Diagnosis c)
        {
            if (ModelState.IsValid)
            {
                _Context.Diagnosis.Add(c);
                _Context.SaveChanges();
                TempData["SuccessMessage"] = "Diagnosis form have been saved Successfully!";
                return RedirectToAction("Diagnosis");
            }
            else
            {
                return View();
            }
        }
        public IActionResult Diagnosis()
        {
            IEnumerable<Diagnosis> objList = _Context.Diagnosis;
            return View(objList);
        }
        [HttpGet]
        public IActionResult ViewDiagnosis(int? ID)
        {
            if (ID == null || ID == 0)
            {
                return NotFound();
            }
            var obj = _Context.Diagnosis.Find(ID);
            if (obj == null)
            {
                return NotFound();
            }




            return View(obj);
        } 
        [HttpGet]
        public IActionResult UpdateDiagnosis(int? ID)
        {
            if (ID == null || ID == 0)
            {
                return NotFound();
            }
            var obj = _Context.Diagnosis.Find(ID);
            if (obj == null)
            {
                return NotFound();
            }




            return View(obj);
        }
        public IActionResult DeleteDiagnosis(int? ID)
        {
            var obj = _Context.Diagnosis.Find(ID);
            if (obj == null)
            {
                return NotFound();
            }

            _Context.Diagnosis.Remove(obj);
            _Context.SaveChanges();
            TempData["SuccessMessage"] = "Deleted !";
            return RedirectToAction("Diagnosis");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateDiagnosis(Diagnosis obj)
        {
            _Context.Diagnosis.Update(obj);
            _Context.SaveChanges();
            TempData["SuccessMessage"] = "DragonBallz Updated Successfully!";
            return RedirectToAction("Diagnosis");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SavePrescription(ChronicPrescription x)
        {
            if (ModelState.IsValid)
            {
                _Context.ChronicPrescriptions.Add(x);
                _Context.SaveChanges();
                TempData["SuccessMessage"] = "Prescription form have been saved successfully!";
                return RedirectToAction("ViewPrescription");
            }
            else
            {
                return View();
            }
        }
        public IActionResult DeletePrescription(int? ID)
        {
            var obj = _Context.ChronicPrescriptions.Find(ID);
            if (obj == null)
            {
                return NotFound();
            }

            _Context.ChronicPrescriptions.Remove(obj);
            _Context.SaveChanges();
            TempData["SuccessMessage"] = "Deleted !";
            return RedirectToAction("ViewPrescription");
        }
        public IActionResult SavePrescription()
        {
            return View();
        }
       
        public IActionResult Notes()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Notes(Notes x)
        {
            if (ModelState.IsValid)
            {
                _Context.Notes.Add(x);
                _Context.SaveChanges();
                TempData["SuccessMessage"] = "Note sent !";
                return RedirectToAction("DocNotes");
            }
            else
            {
                return View();
            }


        }
        public IActionResult DocNotes()
        {
            IEnumerable<Notes> objList = _Context.Notes;
            return View(objList);
        }

        public IActionResult DeleteNotes(int? ID)
        {
            var obj = _Context.Notes.Find(ID);
            if (obj == null)
            {
                return NotFound();
            }

            _Context.Notes.Remove(obj);
            _Context.SaveChanges();
            TempData["SuccessMessage"] = "Deleted !";
            return RedirectToAction("DocNotes");
        }
        public IActionResult ViewPrescription()
        {
            IEnumerable<ChronicPrescription> objList = _Context.ChronicPrescriptions;
            return View(objList);
        }
        [HttpGet]
        public IActionResult Prescriptions(int? ID)
        {
            if (ID == null || ID == 0)
            {
                return NotFound();
            }
            var obj = _Context.ChronicPrescriptions.Find(ID);
            if (obj == null)
            {
                return NotFound();
            }




            return View(obj);
        }
        [HttpGet]
        public IActionResult UpdatePrescription(int? ID)
        {
            if (ID == null || ID == 0)
            {
                return NotFound();
            }
            var obj = _Context.ChronicPrescriptions.Find(ID);
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdatePrescription(ChronicPrescription obj)
        {

            _Context.ChronicPrescriptions.Update(obj);
            _Context.SaveChanges();
            TempData["SuccessMessage"] = "DragonBallz Updated Successfully!";
            return RedirectToAction("ViewPrescription");
        }
    

        public IActionResult FollowUpMeetings()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult FollowUpMeetings(NextMeetings x)
        {
            if (ModelState.IsValid)
            {
                _Context.NextMeetings.Add(x);
                _Context.SaveChanges();
                TempData["SuccessMessage"] = "Booked successfully !";
                return RedirectToAction("FollowUpMeetings");
            }
            else
            {
                return View();
            }
        }
        public IActionResult ViewAppointments()
        {
            IEnumerable<NextMeetings> objList = _Context.NextMeetings;
            return View(objList);
        }
        public IActionResult ViewMedicalHistory()
        {
            IEnumerable<ChroMedicalHistory> objList = _Context.ChroMedicalHistory;
            return View(objList);
        }
        [HttpGet]
        public IActionResult View(int? ID)
        {
            if (ID == null || ID == 0)
            {
                return NotFound();
            }
            var obj = _Context.ChroMedicalHistory.Find(ID);
            if (obj == null)
            {
                return NotFound();
            }

         
            
            
                return View(obj);
            
           
                    

        }
       
        public IActionResult viewRefills()
        {
            IEnumerable<ChroniRefills> objList = _Context.ChronRefills;
            return View(objList);
        }
        

    }
}
