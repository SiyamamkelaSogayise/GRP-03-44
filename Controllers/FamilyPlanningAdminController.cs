using GeeksProject02.Data;
using GeeksProject02.Models;
using Microsoft.AspNetCore.Mvc;

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
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]

        public async  Task<IActionResult> Add(FamilyPlanningAdmin FamilyPlanningAdminRequest)
        {
            var familyplanningpatient = new FamilyPlanningPatient()
            {
                Id = Guid.NewGuid(),
                Name = FamilyPlanningAdminRequest.Name,
                Surname = FamilyPlanningAdminRequest.Surname,
                DateOfBirth = FamilyPlanningAdminRequest.DateOfBirth,
                GenderIdentity = FamilyPlanningAdminRequest.GenderIdentity,
                Address = FamilyPlanningAdminRequest.Address,
                PhoneNumber = FamilyPlanningAdminRequest.PhoneNumber,
                Email = FamilyPlanningAdminRequest.Email,
                InsuranceProvider = FamilyPlanningAdminRequest.InsuranceProvider,
                PolicyNumber = FamilyPlanningAdminRequest.PolicyNumber,
                GroupID = FamilyPlanningAdminRequest.GroupID,
                ExistingMedicalConditions = FamilyPlanningAdminRequest.ExistingMedicalConditions,
                Allergies = FamilyPlanningAdminRequest.Allergies,
                CurrentMedications = FamilyPlanningAdminRequest.CurrentMedications,
                SurgicalHistory = FamilyPlanningAdminRequest.SurgicalHistory,
                MenstrualHistory = FamilyPlanningAdminRequest.MenstrualHistory,
                PregnancyHistory = FamilyPlanningAdminRequest.PregnancyHistory,
                ContraceptiveHistory = FamilyPlanningAdminRequest.ContraceptiveHistory,
                STIHistory = FamilyPlanningAdminRequest.STIHistory,
                EmergencyContactName = FamilyPlanningAdminRequest.EmergencyContactName,
                EmergencyContactRelationship = FamilyPlanningAdminRequest.EmergencyContactRelationship,
                EmergencyContactPhoneNumber = FamilyPlanningAdminRequest.EmergencyContactPhoneNumber,
                PreferredDoctor = FamilyPlanningAdminRequest.PreferredDoctor,

            };

            await geeksProject02Context.FamilyPlanningAdmin.AddAsync(familyplanningpatient);
            await geeksProject02Context.SaveChangesAsync();
            return RedirectToAction("Add");


        }
    }
}
