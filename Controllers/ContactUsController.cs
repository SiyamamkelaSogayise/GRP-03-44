using GeeksProject02.Areas.Identity.Data;
using GeeksProject02.Data;
using GeeksProject02.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Plugins;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using System.Security.Cryptography.X509Certificates;

namespace GeeksProject02.Controllers
{
    public class ContactUsController : Controller
    {
        private readonly GeeksProject02Context context;
        public ContactUsController( GeeksProject02Context context)
        {
                this.context = context;
        }
        [HttpGet]
        public  async Task<IActionResult> Add()
        {
            var user = GetUserDetails();
            var viewModel = new ContactUsViewModel
            {
                Name = user.FirstName,
                Email = user.Email,
                
            };
            return View("Add", viewModel);
        }
        private GeeksProject02User GetUserDetails()
        {
            if (User.Identity != null)
            {
                var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value; // Get the user's ID
                var user = context.Users.FirstOrDefault(u => u.Id == userId);

                if (user != null)
                {
                    return user;
                }
            }

            return new GeeksProject02User();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(ContactUsViewModel addContactRequest)
        {
            //if(ModelState.IsValid)
            //{
                var contactUs = new ContactUs()
                {

                    Name = addContactRequest.Name,
                    Email = addContactRequest.Email,
                    Subject = addContactRequest.Subject,
                    Messages = addContactRequest.Messages,
                };
                context.ContactUs.Add(contactUs);
                await context.SaveChangesAsync();

                //return View("Add", addContactRequest);
            //}
            return RedirectToAction("Add");
        }
        [Authorize("Admin")]
        public async Task<IActionResult> Index()
        {
            var contactUs = await context.ContactUs.ToListAsync();
            return View(contactUs);
        }
        [HttpGet]
        public async Task<IActionResult> View(int Id)
        {
            var contactUs = await context.ContactUs.FirstOrDefaultAsync(x => x.Id == Id);
            if (contactUs != null)
            {
                var viewModel = new ContactUsViewModel()
                {

                    Name = contactUs.Name,
                    Email = contactUs.Email,
                    Subject = contactUs.Subject,
                    Messages = contactUs.Messages,

                };
                return await Task.Run(() => View("View", viewModel));
            }
            return RedirectToAction("Index");

        }
        [HttpPost]
        public async Task<IActionResult> View(ContactUsViewModel model)
        {
            var contactUs = await context.ContactUs.FindAsync(model.Id);
            if (contactUs != null)
            {
                contactUs.Name = model.Name;
                contactUs.Email = model.Email;
                contactUs.Subject = model.Subject;
                contactUs.Messages = model.Messages;


                await context.SaveChangesAsync();

                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

    }
}
