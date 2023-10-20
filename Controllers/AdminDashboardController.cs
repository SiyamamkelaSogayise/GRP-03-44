using GeeksProject02.Areas.Identity.Data;
using GeeksProject02.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GeeksProject02.Controllers
{

    public class AdminDashboardController : Controller
    {
        private readonly PatientDBContext patientDBContext;

        public AdminDashboardController(PatientDBContext patientDBContext)
        {
            this.patientDBContext = patientDBContext;
        }
        public async Task<IActionResult> AdminDashboard()
        {
            var addBooking = await patientDBContext.AddBookings.ToListAsync();
            return View(addBooking);
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(AdminViewModel addBookingRequest)
        {
            var addBooking = new AddBooking()
            {
                Id = GenerateId.GenerateUniqueId(),
                FirstName = addBookingRequest.FirstName,
                Surname = addBookingRequest.Surname,
                DOB = addBookingRequest.DOB,
                Gender = addBookingRequest.Gender,
                AvailableDays = addBookingRequest.AvailableDays != null
                ? addBookingRequest.AvailableDays.Select(day => new AvailableDay { Day = day }).ToList()
                : null,
                PreferredAppointmentTime = addBookingRequest.PreferredAppointmentTime != null
                ? addBookingRequest.PreferredAppointmentTime.Select(time => new PreferredAppointmentTime { Time = time }).ToList()
                : null,
                AppointmentDate = addBookingRequest.AppointmentDate
            };
            await patientDBContext.AddBookings.AddAsync(addBooking);
             await patientDBContext.SaveChangesAsync();
            return RedirectToAction("AdminDashboard");
        }
        [HttpGet]
        public async  Task<IActionResult >View(int id)
        {
            var addBooking = await patientDBContext.AddBookings
        .Include(ab => ab.AvailableDays)
        .Include(ab => ab.PreferredAppointmentTime)
        .FirstOrDefaultAsync(x => x.Id == id);
            if (addBooking != null)
            {
                var viewModel = new UpdateViewModel()
                {

                    Id = GenerateId.GenerateUniqueId(),
                    FirstName = addBooking.FirstName,
                    Surname = addBooking.Surname,
                    DOB = addBooking.DOB,
                    Gender = addBooking.Gender,
                    AvailableDays = addBooking.AvailableDays,
                    PreferredAppointmentTime = addBooking.PreferredAppointmentTime,
                    AppointmentDate = addBooking.AppointmentDate
                };
                return await Task.Run(() =>View("View", viewModel));
            }
            return RedirectToAction("AdminDashboard");

        }
        [HttpPost]
        public async Task<IActionResult> View(UpdateViewModel model)
        {
            
            var addBooking = await patientDBContext.AddBookings.FindAsync(model.Id);
            if (addBooking != null)
            {
                addBooking.FirstName = model.FirstName;
                addBooking.Surname = model.Surname;
                addBooking.DOB = model.DOB;
                addBooking.Gender = model.Gender;
                addBooking.AvailableDays = model.AvailableDays;
                addBooking.PreferredAppointmentTime = model.PreferredAppointmentTime;
                addBooking.AppointmentDate = model.AppointmentDate;

                await patientDBContext.SaveChangesAsync();
                return RedirectToAction("AdminDashboard");
            }
            return RedirectToAction("AdminDashboard");

        }
        [HttpPost]
        public async Task<IActionResult> Delete(UpdateViewModel model)
        {
            var addBooking = await patientDBContext.AddBookings.FindAsync(model.Id);

            if (addBooking != null)
            {
                patientDBContext.AddBookings.Remove(addBooking);
                await patientDBContext.SaveChangesAsync();

                return RedirectToAction("AdminDashboard");
            }
            return RedirectToAction("AdminDashboard");
        }





    }
}
