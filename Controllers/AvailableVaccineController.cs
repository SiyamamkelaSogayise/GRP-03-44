using GeeksProject02.Data;
using GeeksProject02.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

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
        public IActionResult AvailableVaccine()
        {
            return View();
        }
        [HttpPost]
        public JsonResult ChangeAvailability(int vaccineId, bool isAvailable)
        {
            
            try
            {
                var vaccine = dbContext.AvailableVaccines.Find(vaccineId);
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
        public ActionResult Add()
        {
            var model = new AddVaccineViewModel();
            return View(model);
        }

        // POST: /Vaccine/Add
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(AddVaccineViewModel addVacineRequest)
        {
            var availableVaccine = new AvailableVaccine()
            {
                Id = Guid.NewGuid(),
                Name = addVacineRequest.Name,
                Description = addVacineRequest.Description,
                IsAvailable = addVacineRequest.IsAvailable,
                RestockDate = addVacineRequest.RestockDate,
                
            };
            await dbContext.AvailableVaccines.AddAsync(availableVaccine);
            await dbContext.SaveChangesAsync();
            return RedirectToAction("AvailableVaccine");

        }

    }
}
