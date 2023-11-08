using GeeksProject02.Data;
using GeeksProject02.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Collections.Generic;

namespace GeeksProject02.Controllers
{
    public class AvailableVaccineController : Controller
    {
        private readonly GeeksProject02Context dbContext;
        public AvailableVaccineController(GeeksProject02Context dbContext)
        {
                this.dbContext = dbContext;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var availableVaccine = await dbContext.AvailableVaccines.ToListAsync();
            return View(availableVaccine);
        }
        
        [HttpPost]
        public JsonResult ChangeAvailability(int Id, bool isAvailable)
        {
            
            try
            {
                var vaccine = dbContext.AvailableVaccines.Find(Id);
                if (vaccine != null)
                {
                    vaccine.IsAvailable = isAvailable;
                    dbContext.SaveChanges();
                    return Json(new { success = true });
                }
                return Json(new { success = false, message = "Vaccine not found." });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }
        [HttpGet]
        public async Task<ActionResult> Add()
        {
            var model = new AddVaccineViewModel();
            return await Task.Run(() => View("Add", model));
        }

        // POST: /Vaccine/Add
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(AddVaccineViewModel addVacineRequest)
        {
            if (addVacineRequest != null)
            {
                var availableVaccine = new AvailableVaccine()
                {
                    Name = addVacineRequest.Name,
                    Description = addVacineRequest.Description,
                    IsAvailable = addVacineRequest.IsAvailable,
                    RestockDate = addVacineRequest.RestockDate,
                };
                await dbContext.AvailableVaccines.AddAsync(availableVaccine);
                await dbContext.SaveChangesAsync();
                return RedirectToAction("Add");
            }
            else
            {
                // Handle the case where addVacineRequest is null
                return RedirectToAction("Add"); // or return an error view
            }
        }
        [HttpGet]
        public IActionResult SearchVaccines(string search)
        {
            // Implement the search logic here
            var vaccines = dbContext.AvailableVaccines.Where(v => v.Name.Contains(search)).ToList();

            return View(vaccines);
        }
        [HttpGet]
        public async Task<IActionResult> View(int Id)
        {
            var availableVaccine = await dbContext.AvailableVaccines.FirstOrDefaultAsync(x => x.Id == Id);
            if (availableVaccine != null)
            {
                var viewModel = new AddVaccineViewModel()
                {
                    
                    Name = availableVaccine.Name,
                    Description = availableVaccine.Description,
                    IsAvailable = availableVaccine.IsAvailable,
                    RestockDate = availableVaccine.RestockDate,
                    
                };
                return await Task.Run(() => View("View", viewModel));
            }
            return RedirectToAction("Index");

        }
        [HttpPost]
        public async Task<IActionResult> View(AddVaccineViewModel model)
        {
            var availableVaccine = await dbContext.AvailableVaccines.FindAsync(model.Id);
            if (availableVaccine != null)
            {
                availableVaccine.Name = model.Name;
                availableVaccine.Description = model.Description;
                availableVaccine.IsAvailable = model.IsAvailable;
                availableVaccine.RestockDate = model.RestockDate;
                

                await dbContext.SaveChangesAsync();

                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

    }
}
