//using GeeksProject02.Data;
//using GeeksProject02.Models;
//using Microsoft.AspNetCore.Mvc;

//namespace GeeksProject02.Controllers
//{
    
//        public class AdultsNextPageController : Controller
//        {

//            private readonly GeeksProject02Context dbcontext;

//            public AdultsNextPageController(GeeksProject02Context geeksProject02Context)
//            {
//                this.dbcontext = geeksProject02Context;
//            }
//            public IActionResult Index()
//            {
//                return View();
//            }
//            [HttpGet]
//            public IActionResult AdultsNextPage()
//            {
//                return View();
//            }
//            [HttpPost]
//            public IActionResult AdultsNextPage(PatientBooking model)
//            {
//                if (ModelState.IsValid)
//                {
//                    // Map the ViewModel to your Appointment entity
//                    var form = new Form()
//                    {
//                        FirstName = model.FirstName,
//                        Surname = model.Surname,
//                        DOB = model.DOB,
//                        Gender = model.Gender,
//                        EmailAddress = model.EmailAddress,
//                        PhoneNumber = model.PhoneNumber,
//                        AdditionalInfo = model.AdditionalInfo,
//                        AppointmentDate = model.AppointmentDate,
//                        IsMedicalAidMember = model.IsMedicalAidMember,
//                        MedicalAidName = model.MedicalAidName,
//                        MedicalAidNumber = model.MedicalAidNumber,



//                        // Map other properties
//                    };

//                    dbcontext.Forms.Add(form);
//                    dbcontext.SaveChanges();

//                TempData["SuccessMessage"] = "Form submitted successfully.";

//                // Redirect to a thank you page or show a success message
//                return RedirectToAction("AdultNextPage"); // Create a "ThankYou" action in your controller
//                }

//                // If ModelState is not valid, return to the form with validation errors
//                return View(model);
//            }
//        }
//}