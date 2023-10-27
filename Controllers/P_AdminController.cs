using Microsoft.AspNetCore.Mvc;
using Dapper;
using Microsoft.Data.SqlClient;
using GeeksProject02.Areas.Identity.Data;
using GeeksProject02.Models;
using GeeksProject02.Data;
using System.Data;
using GeeksProject02.ViewModel;

namespace GeeksProject02.Controllers
{
    public class P_AdminController : Controller
    {
        private string connstring = "Server=SICT-SQL.MANDELA.AC.ZA; user id=GRP-03-44; password=grp-03-44-soit2023#;Database=GRP-03-44-DBInnovaticeHealth;Trusted_Connection=false";

        private readonly GeeksProject02Context _context;

        public P_AdminController(GeeksProject02Context context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult View_Patient()
        {
            string query = @"SELECT pt.pregnancy_ID, pai.first_name, pai.last_name, pai.email, pt.current_week
                             FROM Patient_Info AS pai
                             JOIN Pregnancy_Tracker AS pt ON pai.patient_ID = pt.patient_ID
                             ORDER BY pt.pregnancy_ID";

            using (IDbConnection dbConnection = new SqlConnection(connstring))
            {
                var patients = dbConnection.Query<Patient_Info>(query);
                return View(patients);
            }
        }
    }
}
