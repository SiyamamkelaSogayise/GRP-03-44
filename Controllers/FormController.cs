using GeeksProject02.Data;
using GeeksProject02.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GeeksProject02.Controllers
{
    public class FormController : Controller
    {
        private readonly GeeksProject02Context _dbContext;

        public FormController(GeeksProject02Context dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Form()
        {

            ViewData["Title"] = "Appointment Request";
            ViewData["Description"] = "Book your appointment with us by filling the form below";
            // You can set more ViewData values as needed
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Form([Bind("FirstName,Surname,DOB,Gender,EmailAddress,PhoneNumber,AdditionalInfo,AppointmentDate,IsMedicalAidMember,MedicalAidNumber,MedicalAidName")] Form model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // Directly use the received model for database operations
                    _dbContext.Forms.Add(model);
                    _dbContext.SaveChanges();
                    TempData["AlertMessage"] = "Appointment Form completed successfully!";
                    return RedirectToAction("Form");
                }
                catch (DbUpdateException ex)
                {
                    // Handle database update exception
                    // Log the error and provide user-friendly feedback
                    TempData["ErrorMessage"] = "Medical Historyn errr occurred while savg he for. Pleas try again later.";
                    // Log the exception for further investigation if necessary
                    // _logger.LogError(ex, "Error occurred while saving fSubmittDetails data.");
                }
            }

            // If ModelState is not valid, return the view with the model to display validation errors
            return View(model);
        }
        public async Task<IActionResult> Appointments()
        {
            var form = await _dbContext.Forms.ToListAsync();
            return View(form);
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(Appointments formRequest)
        {
            var form = new Form()
            {
                Id = GenerateId.GenerateUniqueId(),
                FirstName = formRequest.FirstName,
                Surname = formRequest.Surname,
                DOB = formRequest.DOB,
                Gender = formRequest.Gender,
                EmailAddress = formRequest.EmailAddress,
                PhoneNumber = formRequest.PhoneNumber,
                AppointmentDate = formRequest.AppointmentDate,
                IsMedicalAidMember = formRequest.IsMedicalAidMember,
                MedicalAidNumber = formRequest.MedicalAidNumber,
                MedicalAidName = formRequest.MedicalAidName
            };
            await _dbContext.Forms.AddAsync(form);
            await _dbContext.SaveChangesAsync();
            return RedirectToAction("AdminDashboard");
        }
        [HttpGet]
        public async Task<IActionResult> View(int id)
        {
            var form = await _dbContext.Forms.FirstOrDefaultAsync(x => x.Id == id);
            if (form != null)
            {
                var viewModel = new Appointments()
                {

                    Id = GenerateId.GenerateUniqueId(),
                    FirstName = form.FirstName,
                    Surname = form.Surname,
                    DOB = form.DOB,
                    Gender = form.Gender,
                    EmailAddress = form.EmailAddress,
                    PhoneNumber = form.PhoneNumber,
                    AdditionalInfo = form.AdditionalInfo,
                    AppointmentDate = form.AppointmentDate,
                    IsMedicalAidMember = form.IsMedicalAidMember,
                    MedicalAidNumber = form.MedicalAidNumber,
                    MedicalAidName = form.MedicalAidName
                };
                return await Task.Run(() => View("View", viewModel));
            }
            return RedirectToAction("AdminDashboard");

        }
        [HttpPost]
        public async Task<IActionResult> View(Appointments model)
        {

            var form = await _dbContext.Forms.FindAsync(model.Id);
            if (form != null)
            {
                form.FirstName = model.FirstName;
                form.Surname = model.Surname;
                form.DOB = model.DOB;
                form.Gender = model.Gender;
                form.EmailAddress = model.EmailAddress;
                form.PhoneNumber = model.PhoneNumber;
                form.AdditionalInfo = model.AdditionalInfo;
                form.AppointmentDate = model.AppointmentDate;
                form.IsMedicalAidMember = model.IsMedicalAidMember;
                form.MedicalAidNumber = model.MedicalAidNumber;
                form.MedicalAidName = model.MedicalAidName;

                await _dbContext.SaveChangesAsync();
                return RedirectToAction("Appointments");
            }
            return RedirectToAction("Appointments");

        }
        [HttpPost]
        public async Task<IActionResult> Delete(Appointments model)
        {
            var form = await _dbContext.Forms.FindAsync(model.Id);

            if (form != null)
            {
                _dbContext.Forms.Remove(form);
                await _dbContext.SaveChangesAsync();

                return RedirectToAction("AdminDashboard");
            }
            return RedirectToAction("AdminDashboard");
        }





    }
}