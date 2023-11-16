using GeeksProject02.Areas.Identity.Data;
using GeeksProject02.Data;
using GeeksProject02.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace GeeksProject02.Controllers
{
    public class NotesController : Controller
    {
        private readonly GeeksProject02Context DbContext;
        private readonly UserManager<GeeksProject02User> _userManager;
        public NotesController(GeeksProject02Context dbContext, UserManager<GeeksProject02User> userManager)
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
        public async Task<IActionResult> AddNotes()
        {
            var user = GetUserDetails();


            var viewModel = new NotesViewModel
            {
                DoctorName = user.FirstName


            };



            return await Task.Run(() => View("AddNotes", viewModel));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddNotes(NotesViewModel addLastRequest)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier); // Retrieve user ID

            var last = new ChronicNotes()
            {
                Id = Guid.NewGuid(),
                DoctorName = addLastRequest.DoctorName,
                Date = addLastRequest.Date,
             
                subject = addLastRequest.subject,
                Message = addLastRequest.Message,
               


                userId = userId // Assign the user ID
            };

            DbContext.ChronicNotes.Add(last);
            await DbContext.SaveChangesAsync();

            return RedirectToAction("AddNotes");
        }

    }
}
