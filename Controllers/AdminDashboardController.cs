//using GeeksProject02.Areas.Identity.Data;
//using GeeksProject02.Data;
//using GeeksProject02.Models;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;

//namespace GeeksProject02.Controllers
//{

//    public class AdminDashboardController : Controller
//    {
//        private readonly GeeksProject02Context geeksProject02Context;

//        public AdminDashboardController(GeeksProject02Context geeksProject02Context)
//        {
//            this.geeksProject02Context = geeksProject02Context;
//        }
//        public async Task<IActionResult> AdminDashboard()
//        {
//            var form = await geeksProject02Context.Forms.ToListAsync();
//            return View(form);
//        }
//        [HttpGet]
//        public IActionResult Add()
//        {
//            return View();
//        }
//        [HttpPost]
//        public async Task<IActionResult> Add(Appointments formRequest)
//        {
//            var form = new Form()
//            {
//                Id = GenerateId.GenerateUniqueId(),
//                FirstName = formRequest.FirstName,
//                Surname = formRequest.Surname,
//                DOB = formRequest.DOB,
//                Gender = formRequest.Gender,
//                EmailAddress = formRequest.EmailAddress,
//                PhoneNumber = formRequest.PhoneNumber,
//                AppointmentDate = formRequest.AppointmentDate,
//                IsMedicalAidMember = formRequest.IsMedicalAidMember,
//                MedicalAidNumber = formRequest.MedicalAidNumber,
//                MedicalAidName = formRequest.MedicalAidName
//            };
//            await geeksProject02Context.Forms.AddAsync(form);
//            await geeksProject02Context.SaveChangesAsync();
//            return RedirectToAction("AdminDashboard");
//        }
//        [HttpGet]
//        public async Task<IActionResult> View(int id)
//        {
//            var form = await geeksProject02Context.Forms.FirstOrDefaultAsync(x => x.Id == id);
//            if (form != null)
//            {
//                var viewModel = new Appointments()
//                {

//                    Id = GenerateId.GenerateUniqueId(),
//                    FirstName = form.FirstName,
//                    Surname = form.Surname,
//                    DOB = form.DOB,
//                    Gender = form.Gender,
//                    EmailAddress = form.EmailAddress,
//                    PhoneNumber = form.PhoneNumber,
//                    AdditionalInfo = form.AdditionalInfo,
//                    AppointmentDate = form.AppointmentDate,
//                    IsMedicalAidMember = form.IsMedicalAidMember,
//                    MedicalAidNumber = form.MedicalAidNumber,
//                    MedicalAidName = form.MedicalAidName
//                };
//                return await Task.Run(() => View("View", viewModel));
//            }
//            return RedirectToAction("AdminDashboard");

//        }
//        [HttpPost]
//        public async Task<IActionResult> View(Appointments model)
//        {

//            var form = await geeksProject02Context.Forms.FindAsync(model.Id);
//            if (form != null)
//            {
//                form.FirstName = model.FirstName;
//                form.Surname = model.Surname;
//                form.DOB = model.DOB;
//                form.Gender = model.Gender;
//                form.EmailAddress= model.EmailAddress;
//                form.PhoneNumber = model.PhoneNumber;
//                form.AdditionalInfo = model.AdditionalInfo;
//                form.AppointmentDate = model.AppointmentDate;
//                form.IsMedicalAidMember = model.IsMedicalAidMember;
//                form.MedicalAidNumber= model.MedicalAidNumber;
//                form.MedicalAidName= model.MedicalAidName;

//                await geeksProject02Context.SaveChangesAsync();
//                return RedirectToAction("AdminDashboard");
//            }
//            return RedirectToAction("AdminDashboard");

//        }
//        [HttpPost]
//        public async Task<IActionResult> Delete(Appointments model)
//        {
//            var form = await geeksProject02Context.Forms.FindAsync(model.Id);

//            if (form != null)
//            {
//                geeksProject02Context.Forms.Remove(form);
//                await geeksProject02Context.SaveChangesAsync();

//                return RedirectToAction("AdminDashboard");
//            }
//            return RedirectToAction("AdminDashboard");
//        }





//    }
//}
