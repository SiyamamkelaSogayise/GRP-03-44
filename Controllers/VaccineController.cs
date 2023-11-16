using GeeksProject02.Data;
using GeeksProject02.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GeeksProject02.Controllers
{
    public class VaccineController : Controller
    {
        private readonly GeeksProject02Context DbContext;

        public VaccineController(GeeksProject02Context dbContext)
        {
            this.DbContext = dbContext;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Vaccine()
        {
            return View();
        }
        public IActionResult VaccineLocations()
        {
            return View();
        }
        [HttpGet] // Add this attribute for HTTP GET
        public IActionResult SelfScreening()
        {
            return View();
        }

        [HttpPost] // Add this attribute for HTTP POST
        public IActionResult SelfScreening(QuestionnaireResponse response)
        {
            
                // Add the response to the database
                DbContext.QuestionnaireResponses.Add(response);
                DbContext.SaveChanges();

                

            return View(response);
        }

    }

}

