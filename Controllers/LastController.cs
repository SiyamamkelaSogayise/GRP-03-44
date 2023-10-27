using GeeksProject02.Data;
using GeeksProject02.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GeeksProject02.Controllers
{
    public class LastController : Controller
    {
        private readonly ApplicationDbContext DbContext;

        public LastController(ApplicationDbContext dbContext)
        {
            this.DbContext = dbContext;
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
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(LastViewModel addLastRequest) 
        {
            var last = new Last()
            {
                Id = Guid.NewGuid(),
                FirstName = addLastRequest.FirstName,
                Surname = addLastRequest.Surname,
                DOB = addLastRequest.DOB,
                Gender = addLastRequest.Gender,
                EmailAddress = addLastRequest.EmailAddress,
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
                    Surname = last.Surname,
                    DOB = last.DOB,
                    Gender = last.Gender,
                    EmailAddress = last.EmailAddress,
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
                last.Surname = model.Surname;
                last.DOB = model.DOB;
                last.Gender = model.Gender;
                last.EmailAddress = model.EmailAddress;
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
    }
}
