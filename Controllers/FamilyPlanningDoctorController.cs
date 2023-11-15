using GeeksProject02.Areas.Identity.Data;
using GeeksProject02.Data;
using GeeksProject02.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Collections.Generic;
using System.Configuration.Provider;
using System.Text.RegularExpressions;
using System.Xml.Linq;


namespace GeeksProject02.Controllers
{
    public class FamilyPlanningDoctorController : Controller
    {
        private readonly GeeksProject02Context geeksProject02Context;

        public FamilyPlanningDoctorController(GeeksProject02Context geeksProject02Context)
        {
            this.geeksProject02Context = geeksProject02Context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var familyplanningdoctors = await geeksProject02Context.GetFamilyPlanningDoctors.ToListAsync();
            return View(familyplanningdoctors);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(FamilyPlanningDoctor familyPlanningDoctorRequest)
        {
            var familyplanningdoctorpatient = new FamilyPlanningDoctor()
            {
                Id = Guid.NewGuid(),
                DateTime = familyPlanningDoctorRequest.DateTime,
                IDNumber = familyPlanningDoctorRequest.IDNumber,
                Name = familyPlanningDoctorRequest.Name,
                Surname = familyPlanningDoctorRequest.Surname, 
                OfNote = familyPlanningDoctorRequest.OfNote,
                ProviderName = familyPlanningDoctorRequest.ProviderName,
                ReasonForVisit = familyPlanningDoctorRequest.ReasonForVisit,
                Examination = familyPlanningDoctorRequest.Examination,
                EncounterSummary = familyPlanningDoctorRequest.EncounterSummary,
                Prescription = familyPlanningDoctorRequest.Prescription,
               
            };

            await geeksProject02Context.GetFamilyPlanningDoctors.AddAsync(familyplanningdoctorpatient);
            await geeksProject02Context.SaveChangesAsync();
            return RedirectToAction("Add");
        }

        [HttpGet]
        public async Task<IActionResult> View(Guid Id)
        {

            var familyPlanningDoctor = await geeksProject02Context.GetFamilyPlanningDoctors.FirstOrDefaultAsync(x => x.Id == Id);
            if (familyPlanningDoctor != null)
            {
                var viewModel = new FamilyPlanningDoctorUpdate()
                {
                    Id = Guid.NewGuid(),
                    DateTime = familyPlanningDoctor.DateTime,
                    IDNumber = familyPlanningDoctor.IDNumber,
                    Name = familyPlanningDoctor.Name,
                    Surname = familyPlanningDoctor.Surname,
                    OfNote = familyPlanningDoctor.OfNote,
                    ProviderName = familyPlanningDoctor.ProviderName,
                    ReasonForVisit = familyPlanningDoctor.ReasonForVisit,
                    Examination = familyPlanningDoctor.Examination,
                    EncounterSummary = familyPlanningDoctor.EncounterSummary,
                    Prescription = familyPlanningDoctor.Prescription
                };
                return await Task.Run(() => View("View", viewModel));
            }
            return RedirectToAction("Index");
        }



        [HttpPost]
        public async Task<IActionResult> View(FamilyPlanningDoctorUpdate model)
        {
            var familyPlanningDoctor = await geeksProject02Context.GetFamilyPlanningDoctors.FindAsync(model.Id);
            if (familyPlanningDoctor != null)
            {
                
                familyPlanningDoctor.DateTime = model.DateTime;
                familyPlanningDoctor.IDNumber = model.IDNumber;
                familyPlanningDoctor.Name = model.Name;
                familyPlanningDoctor.Surname = model.Surname;
                familyPlanningDoctor.OfNote = model.OfNote;
                familyPlanningDoctor.ProviderName = model.ProviderName;
                familyPlanningDoctor.ReasonForVisit = model.ReasonForVisit;
                familyPlanningDoctor.Examination = model.Examination;
                familyPlanningDoctor.EncounterSummary = model.EncounterSummary;
                familyPlanningDoctor.Prescription = model.Prescription;


                await geeksProject02Context.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> Delete(FamilyPlanningDoctorUpdate model)
        {
            var familyPlanningDoctor = await geeksProject02Context.GetFamilyPlanningDoctors.FindAsync(model.Id);

            if (familyPlanningDoctor != null)
            {
                geeksProject02Context.GetFamilyPlanningDoctors.Remove(familyPlanningDoctor);
                await geeksProject02Context.SaveChangesAsync();

                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
    }
}
