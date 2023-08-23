using Microsoft.AspNetCore.Mvc;

namespace GeeksProject02.Controllers
{
    public class VaccineForAdultsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult VaccineForAdults()
        {
            return View();
        }
        [HttpGet]
        public ActionResult GetDateOfBirth(string idNumber)
        {
            if (!string.IsNullOrEmpty(idNumber))
            {
                if (idNumber.Length != 10)
                {
                    ViewBag.ErrorMessage = "Invalid ID number length";
                }
                else
                {
                    try
                    {
                        int year = int.Parse(idNumber.Substring(0, 2));
                        int month = int.Parse(idNumber.Substring(2, 2));
                        int day = int.Parse(idNumber.Substring(4, 2));

                        if (month < 1 || month > 12 || day < 1 || day > 31)
                        {
                            ViewBag.ErrorMessage = "Invalid month or day";
                        }
                        else
                        {
                            DateTime dateOfBirth = new DateTime(2000 + year, month, day);
                            ViewBag.DateOfBirth = dateOfBirth.ToString("yyyy-MM-dd");
                        }
                    }
                    catch (Exception)
                    {
                        ViewBag.ErrorMessage = "Invalid characters in ID number";
                    }
                }
            }
            else
            {
                ViewBag.DateOfBirth = string.Empty;
            }

            return View();
        }
    }
}


        
        
