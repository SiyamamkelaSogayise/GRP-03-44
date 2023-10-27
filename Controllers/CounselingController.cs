using Microsoft.AspNetCore.Mvc;

namespace GeeksProject02.Controllers
{
    public class CounselingController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Counsel()
        {
            return View();
        }

        public IActionResult CounselBook()
        {
            return View();
        }

        public IActionResult PrefferedTherapist()
        {
            return View();
        }

        public IActionResult CounselingReasont()
        {
            return View();
        }

        public IActionResult CounselAppointment()
        {
            return View();
        }

        public IActionResult CounselingService()
        {
            return View();
        }

        public IActionResult ChildrenTeen()
        {
            return View();
        }

        public IActionResult CounRelationship()
        {
            return View();
        }


        public IActionResult AdultCoun()
        {
            return View();
        }

        public IActionResult AssessementsCoun()
        {
            return View();
        }

        public IActionResult Asseseements()
        {
            return View();
        }



        public IActionResult DialeticalTherapy()
        {
            return View();
        }
        

    [HttpGet]
    public IActionResult Download()
    {
        // Path to your document
        string filePath = "C:\\Users\\s224484575\\Source\\Repos\\GRP-03-44\\wwwroot\\css\\PDF Doc\\Meaningful Minds Psychologists - Mental Health Guide.pdf  "; // Update with the correct path

        // Check if the file exists
        if (System.IO.File.Exists(filePath))
        {
            // Serve the file for download
            var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            return File(fileStream, "application/pdf", "your_document.pdf");
        }
        else
        {
            return NotFound(); // Or return an appropriate error response
        }
    }
    }
}
