using GeeksProject02.Areas.Identity.Data;
using GeeksProject02.Data;
using GeeksProject02.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace GeeksProject02.Controllers
{
    public class PrescribeController : Controller
    {
        private readonly GeeksProject02Context DbContext;
        private readonly UserManager<GeeksProject02User> _userManager;
        public PrescribeController(GeeksProject02Context dbContext, UserManager<GeeksProject02User> userManager)
        {
            this.DbContext = dbContext;
            _userManager = userManager;
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
        [HttpGet]
        public async Task<IActionResult> PrescribeMedicine()
        {
            var user = GetUserDetails();


            var viewModel = new PrescribeViewModel
            {
                DoctorName = user.FirstName
              

            };



            return await Task.Run(() => View("PrescribeMedicine", viewModel));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> PrescribeMedicine(PrescribeViewModel addLastRequest)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier); // Retrieve user ID

            var last = new ChroPrescribe()
            {
                Id = Guid.NewGuid(),
                DoctorName = addLastRequest.DoctorName,
                LicenceNUmber = addLastRequest.LicenceNUmber,
                Date = addLastRequest.Date,
                PatientName = addLastRequest.PatientName,
                MedicationName = addLastRequest.MedicationName,
                DosageInstruction = addLastRequest.DosageInstruction,
                Signiture = addLastRequest.Signiture,

  
                userId = userId // Assign the user ID
            };

            DbContext.ChroPrescribe.Add(last);
            await DbContext.SaveChangesAsync();

            return RedirectToAction("PrescribeMedicine");
        }
    }
}
