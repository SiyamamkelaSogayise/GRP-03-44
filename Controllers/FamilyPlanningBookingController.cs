using GeeksProject02.Areas.Identity.Data;
using GeeksProject02.Data;
using GeeksProject02.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Collections.Generic;
using System.Configuration.Provider;
using System.Security.Claims;
using System.Text.RegularExpressions;
using System.Xml.Linq;


namespace GeeksProject02.Controllers
{
    public class FamilyPlanningBookingController : Controller
    {
        private readonly GeeksProject02Context geeksProject02Context;
        public FamilyPlanningBookingController(GeeksProject02Context geeksProject02Context)
        {
            this.geeksProject02Context = geeksProject02Context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var familyplanningbookings = await geeksProject02Context.GetFamilyPlanningBookings.ToListAsync();
            return View(familyplanningbookings);
        }
        private GeeksProject02User GetUserDetails()
        {
            if (User.Identity != null)
            {
                var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value; // Get the user's ID
                var user = geeksProject02Context.Users.FirstOrDefault(u => u.Id == userId);

                if (user != null)
                {
                    return user;
                }
            }

            return new GeeksProject02User();
        }

        [HttpGet]
        public IActionResult Add()
        {
            var user = GetUserDetails();
            var viewModel = new FamilyPlanningBooking
            {
                Name = user.FirstName,
                Surname = user.LastName,
               
               
            };
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(FamilyPlanningBooking familyPlanningBookingRequest)
        {
            var familyplanningbooking = new FamilyPlanningBooking()
            {
                Id = Guid.NewGuid(),
                Name = familyPlanningBookingRequest.Name,
                Surname = familyPlanningBookingRequest.Surname,
                DateOfBooking = familyPlanningBookingRequest.DateOfBooking,
                IDNumber = familyPlanningBookingRequest.IDNumber,
                BookingReason = familyPlanningBookingRequest.BookingReason,
            };

            await geeksProject02Context.GetFamilyPlanningBookings.AddAsync(familyplanningbooking);
            await geeksProject02Context.SaveChangesAsync();
            return RedirectToAction("Add");
        }

        [HttpGet]
        public async Task<IActionResult> View(Guid Id)
        {

            var familyPlanningBooking = await geeksProject02Context.GetFamilyPlanningBookings.FirstOrDefaultAsync(x => x.Id == Id);
            if (familyPlanningBooking != null)
            {
                var viewModel = new FamilyPlanningBookingUpdate()
                {
                    Id = Guid.NewGuid(),
                    Name = familyPlanningBooking.Name,
                    Surname = familyPlanningBooking.Surname,
                    DateOfBooking = familyPlanningBooking.DateOfBooking,
                    IDNumber = familyPlanningBooking.IDNumber,
                    BookingReason = familyPlanningBooking.BookingReason,
                };
                return await Task.Run(() => View("View", viewModel));
            }
            return RedirectToAction("Index");
        }



        [HttpPost]
        public async Task<IActionResult> View(FamilyPlanningBookingUpdate model)
        {
            var familyPlanningAdmin = await geeksProject02Context.GetFamilyPlanningBookings.FindAsync(model.Id);
            if (familyPlanningAdmin != null)
            {
                
                familyPlanningAdmin.Name = model.Name;
                familyPlanningAdmin.Surname = model.Surname;
                familyPlanningAdmin.DateOfBooking = model.DateOfBooking;
                familyPlanningAdmin.IDNumber = model.IDNumber;
                familyPlanningAdmin.BookingReason = model.BookingReason;
               
                await geeksProject02Context.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> Delete(FamilyPlanningBookingUpdate model)
        {
            var familyPlanningBooking = await geeksProject02Context.GetFamilyPlanningBookings.FindAsync(model.Id);

            if (familyPlanningBooking != null)
            {
                geeksProject02Context.GetFamilyPlanningBookings.Remove(familyPlanningBooking);
                await geeksProject02Context.SaveChangesAsync();

                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
    }
}

