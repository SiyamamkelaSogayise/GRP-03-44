using System.Net.Http;
using System.Threading.Tasks;
using GeeksProject02.Models;
using Humanizer.Localisation;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace GeeksProject02.Controllers
{
    public class ReportController : Controller
    {
        public async Task<ActionResult> Index()
        {
            
            return View();
        }
    }
}