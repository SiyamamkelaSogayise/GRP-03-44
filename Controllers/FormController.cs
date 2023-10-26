using GeeksProject02.Data;
using GeeksProject02.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace GeeksProject02.Controllers
{
    public class FormController : Controller
    {
        private readonly GeeksProject02Context _dbContext;
        private readonly IEmailService _emailService;
        private readonly IOptions<IEmailService> _emailSettings; // Add this line

        public FormController(GeeksProject02Context dbContext, IEmailService emailService, IOptions<IEmailService> emailSettings)
        {
            _dbContext = dbContext;
            _emailService = emailService;
            _emailSettings = emailSettings; // Add this line
        }
        public async Task<IActionResult> AppointmentsData()
        {
            // Retrieve user data
            var userData = await _dbContext.Patient.ToListAsync();

            // Retrieve administrative data (assuming AdminAppointments has a foreign key to UserAppointments)
            var adminData = await _dbContext.Forms.Include(a => a.UserAppointment).ToListAsync();

            // Now you can use userData and adminData as needed

            // For example, you might want to pass this data to a view
            return View(new AppointmentsViewModel
            {
                UserData = userData,
                AdminData = adminData
            });
        }
            //[Authorize("PatientOnly")]
            public IActionResult Index()
        {

            ViewData["Title"] = "Appointment Request";
            ViewData["Description"] = "Book your appointment with us by filling the form below";
            // You can set more ViewData values as needed
            return View();
        }
        //[Authorize("PatientOnly")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index([Bind("FirstName,Surname,DOB,Gender,EmailAddress,PhoneNumber,AdditionalInfo,AppointmentDate,IsMedicalAidMember,MedicalAidNumber,MedicalAidName")] Patient model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // Directly use the received model for database operations
                    _dbContext.Patient.Add(model);
                    _dbContext.SaveChanges();
                    TempData["AlertMessage"] = "Appointment Form completed successfully!";
                    return RedirectToAction("Index");
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
        //[Authorize("AdminOnly")]
        public async Task<IActionResult> Appointments()
        {
            var form = await _dbContext.Forms.ToListAsync();
            return View(form);
        }
        //[Authorize("AdminOnly")]
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        //[Authorize("AdminOnly")]
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
        //[Authorize("AdminOnly")]
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
            return RedirectToAction("Appointments");

        }
        //[Authorize("AdminOnly")]
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
        //[Authorize("AdminOnly")]
        [HttpPost]
        public async Task<IActionResult> Delete(Appointments model)
        {
            var form = await _dbContext.Forms.FindAsync(model.Id);

            if (form != null)
            {
                _dbContext.Forms.Remove(form);
                await _dbContext.SaveChangesAsync();

                return RedirectToAction("Appointments");
            }
            return RedirectToAction("Appointments");
        }
        //[Authorize("AdminOnly")]
        public IActionResult AcceptAppointment(int id)
        {
            var form = _dbContext.Forms.Find(id);
            if (form != null)
            {
                form.Status = Form.AppointmentStatus.Accepted;
                _dbContext.SaveChanges();

                // Send email notification
                string toEmail = form.EmailAddress;
                string subject = "Appointment Status: Accepted";
                string message = "Your appointment has been accepted. Details...";
                _emailService.SendAppointmentStatusEmailAsync(toEmail, subject, message).Wait();
            }

            return RedirectToAction("Appointments");
        }

        //[Authorize("AdminOnly")]
        public IActionResult DeclineAppointment(int id)
        {
            var form = _dbContext.Forms.Find(id);
            if (form != null)
            {
                form.Status = Form.AppointmentStatus.Declined;
                _dbContext.SaveChanges();

                // Send email notification
                string toEmail = form.EmailAddress;
                string subject = "Appointment Status: Declined";
                string message = "Your appointment has been declined. Details...";
                _emailService.SendAppointmentStatusEmailAsync(toEmail, subject, message).Wait();
            }

            return RedirectToAction("Appointments");
        }



    }
}