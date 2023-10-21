﻿using GeeksProject02.Data;
using GeeksProject02.Models;
using Microsoft.AspNetCore.Mvc;

namespace GeeksProject02.Controllers
{
    
        public class AdultsNextPageController : Controller
        {

            private readonly GeeksProject02Context geeksProject02Context;

            public AdultsNextPageController(GeeksProject02Context geeksProject02Context)
            {
                this.geeksProject02Context = geeksProject02Context;
            }
            public IActionResult Index()
            {
                return View();
            }
            [HttpGet]
            public IActionResult AdultsNextPage()
            {
                return View();
            }
            [HttpPost]
            public IActionResult AdultsNextPage(PatientBooking model)
            {
                if (ModelState.IsValid)
                {
                    // Map the ViewModel to your Appointment entity
                    var patientBooking = new PatientBooking()
                    {
                        FirstName = model.FirstName,
                        Surname = model.Surname,
                        DOB = model.DOB,
                        Gender = model.Gender,
                        EmailAddress = model.EmailAddress,
                        PhoneNumber = model.PhoneNumber,
                        AdditionalInfo = model.AdditionalInfo,
                        AppointmentDate = model.AppointmentDate,
                        IsMedicalAidMember = model.IsMedicalAidMember,
                        MedicalAidName = model.MedicalAidName,
                        MedicalAidNumber = model.MedicalAidNumber,



                        // Map other properties
                    };

                    geeksProject02Context.PatientBookings.Add(patientBooking);
                    geeksProject02Context.SaveChanges();

                    // Redirect to a thank you page or show a success message
                    return RedirectToAction("AdultNextPage"); // Create a "ThankYou" action in your controller
                }

                // If ModelState is not valid, return to the form with validation errors
                return View(model);
            }
        }
}