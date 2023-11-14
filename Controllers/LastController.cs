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

namespace GeeksProject02.Controllers
{
    public class LastController : Controller
    {
        private readonly GeeksProject02Context DbContext;
        //private readonly ReportService _reportService;

        public LastController(GeeksProject02Context dbContext)
        {
            this.DbContext = dbContext;
            //_reportService = reportService;
        }

        //public async Task<IActionResult> VaccineReport()
        //{
        //    var reportData = await _reportService.GetMostBookedVaccinesAsync();
        //    return View(reportData);
        //}
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
            foreach (var last in lasts)
            {
                if (last.SelectedVaccine == null )
                {
                    
                    last.SelectedVaccine = "N/A";
                   
                }
                

            }

            return View(lasts);

        }
        
        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var user = GetUserDetails();
            var vaccineList = await DbContext.Stocks
                .Select(s => new SelectListItem
                {
                    Value = s.VaccineName,
                    Text = s.VaccineName // Use only the vaccine name without status
                })
                .ToListAsync();

            var viewModel = new LastViewModel
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                VaccineList = vaccineList
            };

            ViewBag.VaccineList = vaccineList; // Pass vaccineList to ViewBag

            return await Task.Run(() => View("Add", viewModel));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(LastViewModel addLastRequest)
        {
            //if (ModelState.IsValid)
            //{
                // Your other validation logic...

                 // No need to split

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
                    MedicalAidName = addLastRequest.MedicalAidName,
                    SelectedVaccine = addLastRequest.SelectedVaccine
                };

                DbContext.Lasts.Add(last);
                await DbContext.SaveChangesAsync();

                return RedirectToAction("Add");
            //}

            // Your other ModelState not valid logic...

            //ViewBag.VaccineList = await DbContext.Stocks
            //    .Select(s => new SelectListItem
            //    {
            //        Value = s.VaccineName,
            //        Text = s.VaccineName // Use only the vaccine name without status
            //    })
            //    .ToListAsync();

            //return View(addLastRequest);
        }

       

        [Authorize("Admin")]
        [HttpGet]
        public async Task<IActionResult > View(Guid Id)
        {
            var last =  await DbContext.Lasts.FirstOrDefaultAsync(x => x.Id == Id);
            if (last != null)
            {
                var vaccineList = await DbContext.Stocks
                .Select(s => new SelectListItem
                {
                    Value = s.VaccineName,
                    Text = s.VaccineName // Use only the vaccine name without status
                })
                .ToListAsync();
                var viewModel = new UpdateBookingViewModel()
                {
                    Id = last.Id,
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
                    MedicalAidName = last.MedicalAidName,
                    SelectedVaccine = last.SelectedVaccine,
                    VaccineList = vaccineList

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
                last.SelectedVaccine = model.SelectedVaccine;
                //last.SelectedVaccineStatus= model.SelectedVaccineStatus;

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
