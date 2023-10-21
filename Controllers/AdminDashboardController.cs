using GeeksProject02.Areas.Identity.Data;
using GeeksProject02.Data;
using GeeksProject02.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GeeksProject02.Controllers
{

    public class AdminDashboardController : Controller
    {
        private readonly GeeksProject02Context geeksProject02Context;

        public AdminDashboardController(GeeksProject02Context geeksProject02Context)
        {
            this.geeksProject02Context = geeksProject02Context;
        }
        public async Task<IActionResult> AdminDashboard()
        {
            var addBooking = await geeksProject02Context.AddBookings.ToListAsync();
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
                AppointmentDate = addBookingRequest.AppointmentDate,
                IsMedicalAidMember = addBookingRequest.IsMedicalAidMember
            };
            await geeksProject02Context.AddBookings.AddAsync(addBooking);
             await geeksProject02Context.SaveChangesAsync();
            return RedirectToAction("AdminDashboard");
        }
        [HttpGet]
        public async  Task<IActionResult >View(int id)
        {
            var addBooking = await geeksProject02Context.AddBookings.FirstOrDefaultAsync(x => x.Id == id);
            if (addBooking != null)
            {
                var viewModel = new AdminViewModel()
                {

                    Id = GenerateId.GenerateUniqueId(),
                    FirstName = addBooking.FirstName,
                    Surname = addBooking.Surname,
                    DOB = addBooking.DOB,
                    Gender = addBooking.Gender,
                    AppointmentDate = addBooking.AppointmentDate,
                    IsMedicalAidMember = addBooking.IsMedicalAidMember,
                };
                return await Task.Run(() =>View("View", viewModel));
            }
            return RedirectToAction("AdminDashboard");

        }
        [HttpPost]
        public async Task<IActionResult> View(AdminViewModel model)
        {
            
            var addBooking = await geeksProject02Context.AddBookings.FindAsync(model.Id);
            if (addBooking != null)
            {
                addBooking.FirstName = model.FirstName;
                addBooking.Surname = model.Surname;
                addBooking.DOB = model.DOB;
                addBooking.Gender = model.Gender;
                addBooking.AppointmentDate = model.AppointmentDate;
                addBooking.IsMedicalAidMember= model.IsMedicalAidMember;

                await geeksProject02Context.SaveChangesAsync();
                return RedirectToAction("AdminDashboard");
            }
            return RedirectToAction("AdminDashboard");

        }
        [HttpPost]
        public async Task<IActionResult> Delete(AdminViewModel model)
        {
            var addBooking = await geeksProject02Context.AddBookings.FindAsync(model.Id);

            if (addBooking != null)
            {
                geeksProject02Context.AddBookings.Remove(addBooking);
                await geeksProject02Context.SaveChangesAsync();

                return RedirectToAction("AdminDashboard");
            }
            return RedirectToAction("AdminDashboard");
        }





    }
}
