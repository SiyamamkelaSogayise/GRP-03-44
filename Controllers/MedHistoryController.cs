using GeeksProject02.Areas.Identity.Data;
using GeeksProject02.Data;
using GeeksProject02.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static System.Net.Mime.MediaTypeNames;
using System.Reflection.Metadata;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Diagnostics;
using Humanizer;
using static System.Formats.Asn1.AsnWriter;
using System.Collections;
using System.IO;
using System.Xml.Linq;
using System;
using Microsoft.AspNetCore.Identity;

namespace GeeksProject02.Controllers
{
    public class MedHistoryController : Controller
    {

        private readonly GeeksProject02Context DbContext;
        private readonly UserManager<GeeksProject02User> _userManager;
        public MedHistoryController(GeeksProject02Context dbContext, UserManager<GeeksProject02User> userManager)
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
        public async Task<IActionResult> AddHistory()
        {
            var user = GetUserDetails();


            var viewModel = new ChroViewHistoryModel
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,

            };



            return await Task.Run(() => View("AddHistory", viewModel));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddHistory(ChroViewHistoryModel addLastRequest)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier); // Retrieve user ID

            var last = new ChroMedicalHistory()
            {
                Id = Guid.NewGuid(),
                FirstName = addLastRequest.FirstName,
                LastName = addLastRequest.LastName,
            
                Gender = addLastRequest.Gender,
                Email = addLastRequest.Email,
                MobileNumber = addLastRequest.MobileNumber,
                Status = addLastRequest.Status,
                DateOfBirth = addLastRequest.DateOfBirth,
                LifeStyle = addLastRequest.LifeStyle,
                Allergies = addLastRequest.Allergies,
                surgiersUndergone = addLastRequest.surgiersUndergone,
                FamilyMedicalHistory = addLastRequest.FamilyMedicalHistory,
                PreviousMedication = addLastRequest.PreviousMedication,
                ImmunizationHistory = addLastRequest.ImmunizationHistory,
                Hospitalizations = addLastRequest.Hospitalizations,
                HomeTelePhoneNumber=addLastRequest.HomeTelePhoneNumber,
                WorkTelePhoneNumber = addLastRequest.WorkTelePhoneNumber,
                NextOfKinNumber = addLastRequest.NextOfKinNumber,
                InsurenceProvideNumber = addLastRequest.InsurenceProvideNumber,
                userId = userId // Assign the user ID
            };

            DbContext.ChroMedicalHistory.Add(last);
            await DbContext.SaveChangesAsync();

            return RedirectToAction("AddHistory");
        }
    }
}
