using GeeksProject02.Areas.Identity.Data;
using GeeksProject02.Data;
using GeeksProject02.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static System.Net.Mime.MediaTypeNames;
using System.Reflection.Metadata;
using System.Security.Claims;

namespace GeeksProject02.Controllers
{
    public class LastController : Controller
    {
        private readonly GeeksProject02Context DbContext;

        public LastController(GeeksProject02Context dbContext)
        {
            this.DbContext = dbContext;
        }


        private GeeksProject02User GetUserDetails()
        {
            if (User.Identity != null)
            {
                var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value; // Get the user's ID
                var user = DbContext.Users.FirstOrDefault(u => u.Id == userId);

                if (user != null)
                {
                    return user;
                }
            }

            return new GeeksProject02User();
        }

        [Authorize("Admin")]
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var lasts = await DbContext.Lasts.ToListAsync();
            return View(lasts);

        }
        [HttpGet]
        
        public IActionResult Add()
        {
            var user = GetUserDetails(); // Replace with actual code to fetch user data

            var viewModel = new LastViewModel
            {
                FirstName = user.FirstName, // Replace with actual property names in your user model
                LastName = user.LastName,
                Email = user.Email
                // Other properties
            };

            return View(viewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Add(LastViewModel addLastRequest) 
        {
            var last = new Last()
            {
                Id = Guid.NewGuid(),
                FirstName = addLastRequest.FirstName,
                LastName = addLastRequest.LastName,
                DOB = addLastRequest.DOB,
                Gender = addLastRequest.Gender,
                Email = addLastRequest.Email,
                PhoneNumber = addLastRequest.PhoneNumber,
                AdditionalInfo = addLastRequest.AdditionalInfo,
                AppointmentDate = addLastRequest.AppointmentDate,
                IsMedicalAidMember = addLastRequest.IsMedicalAidMember,
                MedicalAidNumber = addLastRequest.MedicalAidNumber,
                MedicalAidName = addLastRequest.MedicalAidName
            };
            await DbContext.Lasts.AddAsync(last);
            await DbContext.SaveChangesAsync();
            return RedirectToAction("Add");

        }
        [Authorize("Admin")]
        [HttpGet]
        public async Task<IActionResult > View(Guid Id)
        {
            var last =  await DbContext.Lasts.FirstOrDefaultAsync(x => x.Id == Id);
            if (last != null)
            {
                var viewModel = new UpdateBookingViewModel()
                {
                    Id = Guid.NewGuid(),
                    FirstName = last.FirstName,
                    LastName = last.LastName,
                    DOB = last.DOB,
                    Gender = last.Gender,
                    Email = last.Email,
                    PhoneNumber = last.PhoneNumber,
                    AdditionalInfo = last.AdditionalInfo,
                    AppointmentDate = last.AppointmentDate,
                    IsMedicalAidMember = last.IsMedicalAidMember,
                    MedicalAidNumber = last.MedicalAidNumber,
                    MedicalAidName = last.MedicalAidName
                };
            return await Task.Run(()=> View("View",viewModel));
            }
            return RedirectToAction("Index");
            
        }
        [Authorize("Admin")]
        [HttpPost]
        public async Task<IActionResult> View(UpdateBookingViewModel model)
        {
            var last = await DbContext.Lasts.FindAsync(model.Id);
            if (last != null)
            {
                last.FirstName = model.FirstName;
                last.LastName = model.LastName;
                last.DOB = model.DOB;
                last.Gender = model.Gender;
                last.Email = model.Email;
                last.PhoneNumber = model.PhoneNumber;
                last.AdditionalInfo = model.AdditionalInfo;
                last.IsMedicalAidMember = model.IsMedicalAidMember;
                last.MedicalAidNumber= model.MedicalAidNumber;
                last.MedicalAidName = model.MedicalAidName;

                await DbContext.SaveChangesAsync();

                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
        [Authorize("Admin")]
        [HttpPost]
        public async Task<IActionResult> Delete(UpdateBookingViewModel model)
        {
            var last = await DbContext.Lasts.FindAsync(model.Id);

            if (last != null)
            {
                 DbContext.Lasts.Remove(last);
                await DbContext.SaveChangesAsync();

                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
        public IActionResult AddVaccine()
        {

            var availableVaccines = GetAvailableVaccines();

            var model = new LastViewModel
            {
                AvailableVaccines = availableVaccines,
                // ... other properties
            };

            return View(model);
        }

        // Assuming this method retrieves the list of available vaccines from the database
        private List<Stock> GetAvailableVaccines()
        {
            
            var stock = DbContext.Stocks
                .Where(v => v.Status == "Available" || v.Status == "Low Stock" || v.Status == "Unavailable")
                .ToList();

            return stock;
        }
    }
}
