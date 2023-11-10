using GeeksProject02.Areas.Identity.Data;
using GeeksProject02.Data;
using GeeksProject02.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Xml.Linq;


namespace GeeksProject02.Controllers
{
    public class FamilyPlanningAdminController : Controller
    {
        private readonly GeeksProject02Context geeksProject02Context;

        public FamilyPlanningAdminController(GeeksProject02Context geeksProject02Context)
        {
            this.geeksProject02Context = geeksProject02Context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
			var familyplanningadmins = await geeksProject02Context.GetFamilyPlanningAdmins.ToListAsync();
            return View(familyplanningadmins);
        }
         
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]

        public async  Task<IActionResult> Add(FamilyPlanningAdmin familyPlanningAdminRequest)
        {
            var familyplanningpatient = new FamilyPlanningAdmin()
            {
                Id = Guid.NewGuid(),
                Name = familyPlanningAdminRequest.Name,
                Surname = familyPlanningAdminRequest.Surname,
                DateOfBirth = familyPlanningAdminRequest.DateOfBirth,
                GenderIdentity = familyPlanningAdminRequest.GenderIdentity,
                Address = familyPlanningAdminRequest.Address,
                PhoneNumber = familyPlanningAdminRequest.PhoneNumber,
                Email = familyPlanningAdminRequest.Email,
                InsuranceProvider = familyPlanningAdminRequest.InsuranceProvider,
                PolicyNumber = familyPlanningAdminRequest.PolicyNumber,
                GroupID = familyPlanningAdminRequest.GroupID,
                ExistingMedicalConditions = familyPlanningAdminRequest.ExistingMedicalConditions,
                Allergies = familyPlanningAdminRequest.Allergies,
                CurrentMedications = familyPlanningAdminRequest.CurrentMedications,
                SurgicalHistory = familyPlanningAdminRequest.SurgicalHistory,
                MenstrualHistory = familyPlanningAdminRequest.MenstrualHistory,
                PregnancyHistory = familyPlanningAdminRequest.PregnancyHistory,
                ContraceptiveHistory = familyPlanningAdminRequest.ContraceptiveHistory,
                STIHistory = familyPlanningAdminRequest.STIHistory,
                EmergencyContactName = familyPlanningAdminRequest.EmergencyContactName,
                EmergencyContactRelationship = familyPlanningAdminRequest.EmergencyContactRelationship,
                EmergencyContactPhoneNumber = familyPlanningAdminRequest.EmergencyContactPhoneNumber,
                PreferredDoctor = familyPlanningAdminRequest.PreferredDoctor,

            };

            await geeksProject02Context.GetFamilyPlanningAdmins.AddAsync(familyplanningpatient);
            await geeksProject02Context.SaveChangesAsync();
            return RedirectToAction("Add");


        }
        [HttpPost]
        public async Task<IActionResult> View(Guid Id)
        {
            var familyPlanningAdmin = await GeeksProject02Context.FamilyPlanningAdminUpdate.FirstOrDefaultAsync(x => x.Id == Id);

            if (familyPlanningAdmin == null)
            {
                var viewModel = new FamilyPlanningAdminUpdate()
                {

                    Id = Guid.NewGuid(),
                    Name = familyPlanningAdmin.Name,
                    Surname = familyPlanningAdmin.Surname,
                    DateOfBirth = familyPlanningAdmin.DateOfBirth,
                    GenderIdentity = familyPlanningAdmin.GenderIdentity,
                    Address = familyPlanningAdmin.Address,
                    PhoneNumber = familyPlanningAdmin.PhoneNumber,
                    Email = familyPlanningAdmin.Email,
                    InsuranceProvider = familyPlanningAdmin.InsuranceProvider,
                    PolicyNumber = familyPlanningAdmin.PolicyNumber,
                    GroupID = familyPlanningAdmin.GroupID,
                    ExistingMedicalConditions = familyPlanningAdmin.ExistingMedicalConditions,
                    Allergies = familyPlanningAdmin.Allergies,
                    CurrentMedications = familyPlanningAdmin.CurrentMedications,
                    SurgicalHistory = familyPlanningAdmin.SurgicalHistory,
                    MenstrualHistory = familyPlanningAdmin.MenstrualHistory,
                    PregnancyHistory = familyPlanningAdmin.PregnancyHistory,
                    ContraceptiveHistory = familyPlanningAdmin.ContraceptiveHistory,
                    STIHistory = familyPlanningAdmin.STIHistory,
                    EmergencyContactName = familyPlanningAdmin.EmergencyContactName,
                    EmergencyContactRelationship = familyPlanningAdmin.EmergencyContactRelationship,
                    EmergencyContactPhoneNumber = familyPlanningAdmin.EmergencyContactPhoneNumber,
                    PreferredDoctor = familyPlanningAdmin.PreferredDoctor
                };

                return await Task.Run(() => View("View", viewModel));
            }

            return RedirectToAction("Index");
        }

    }
}
