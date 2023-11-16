using Microsoft.AspNetCore.Mvc;
using Dapper;
using Microsoft.Data.SqlClient;
using GeeksProject02.Areas.Identity.Data;
using GeeksProject02.Models;
using GeeksProject02.Data;
using System.Data;
using GeeksProject02.ViewModel;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace GeeksProject02.Controllers
{
    public class P_AdminController : Controller
    {
        private string connstring = "Server=SICT-SQL.MANDELA.AC.ZA; user id=GRP-03-44; password=grp-03-44-soit2023#;Database=GRP-03-44-DBInnovaticeHealth;Trusted_Connection=false";

        private readonly GeeksProject02Context _context;
        private readonly UserManager<GeeksProject02User> _userManager;

        public P_AdminController(GeeksProject02Context context, UserManager<GeeksProject02User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        
        private GeeksProject02User GetUserDetails()
        {
            if (User.Identity != null)
            {
                var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value; // Get the user's ID
                var user = _context.Users.FirstOrDefault(u => u.Id == userId);

                if (user != null)
                {
                    return user;
                }
            }

            return new GeeksProject02User();
        }
        public IActionResult Index()
        {
            return View();
        }

        //******************************************************************************************************************
        //************************************************ Prenatal Appointments ******************************************
        //******************************************************************************************************************
        //[Authorize("Admin")]
        //[Authorize("Doctor")]
        public IActionResult View_Patient()
        {
            //string query = @"SELECT pt.pregnancy_ID, pai.first_name, pai.last_name, pai.email, pt.current_week
            //                 FROM Patient_Info AS pai
            //                 JOIN Pregnancy_Tracker AS pt ON pai.patient_ID = pt.patient_ID
            //                 ORDER BY pt.pregnancy_ID";

            //using (IDbConnection dbConnection = new SqlConnection(connstring))
            //{
            //    var patients = dbConnection.Query<Patient_Info>(query);
            //    return View(patients);
            //}
            var appoint = _context.Appointments_Ps.Where(x => x.Status == 'A').ToList();
            return View(appoint);
        }
        //******************************************************************************************************************
        public IActionResult Create_A()
        {
            var user = GetUserDetails();

            var viewModel = new Appointments_P
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email
            };

            return View(viewModel);
        }

        //POST-Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create_A(Appointments_P appointments)
        {
            if (ModelState.IsValid)
            {
                _context.Appointments_Ps.Add(appointments);
                _context.SaveChanges();

                if (User.IsInRole("Doctor"))
                {
                    return RedirectToAction("View_Patient");
                }
                if (User.IsInRole("Admin"))
                {
                    return RedirectToAction("View_Patient");
                }
                else
                {
                    TempData["Message"] = "Application has been Submitted Successfully !";
                    return RedirectToAction("Create_A");
                }
            }
            return View(appointments);
        }

        //basically error checking and good practice ***********************************************************************
        public IActionResult Update_A(int? Id)
        {
            if (Id == null || Id == 0)
            {
                return NotFound();
            }
            var obj = _context.Appointments_Ps.Find(Id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        //POST-Update, actually updating the data
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update_A(Appointments_P appointments)
        {
            _context.Appointments_Ps.Update(appointments);
            _context.SaveChanges();
            return RedirectToAction("View_Patient");
        }

        //basically error checking and good practice ***********************************************************************
        public IActionResult Delete_A(int? Id)
        {
            if (Id == null || Id == 0)
            {
                return NotFound();
            }
            var obj = _context.Appointments_Ps.Find(Id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        //POST-Delete, actually deleting the data
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete_A(Appointments_P appointments)
        {
            _context.Appointments_Ps.Remove(appointments);
            _context.SaveChanges();
            return RedirectToAction("View_Patient");
        }

        //******************************************************************************************************************
        //************************************************ Mummy_N_Me ******************************************************
        //******************************************************************************************************************
        //[Authorize("Admin")]
        //[Authorize("Doctor")]
        public IActionResult Mummy_N()
        {
            var member = _context.Mummy_N_Me.Where(x => x.Status == 'A').ToList();
            return View(member);
        }
        //Adding the member... *********************************************************************************************
        public IActionResult Create_M()
        {
            var user = GetUserDetails();

            var viewModel = new Mummy_n_Me_P
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email
            };

            return View(viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create_M(Mummy_n_Me_P member)
        {
            if (ModelState.IsValid)
            {
                _context.Mummy_N_Me.Add(member);
                _context.SaveChanges();

                if (User.IsInRole("Admin"))
                {
                    return RedirectToAction("Mummy_N");
                }
                else
                {
                    return View(member);
                }
            }
            return View(member);
        }

        //Updating the member... *******************************************************************************************
        public IActionResult Update_M(int? Id)
        {
            if (Id == null || Id == 0)
            {
                return NotFound();
            }
            var obj = _context.Mummy_N_Me.Find(Id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update_M(Mummy_n_Me_P member)
        {
            _context.Mummy_N_Me.Update(member);
            _context.SaveChanges();
            return RedirectToAction("Mummy_N");
        }

        //Deleting the member... *******************************************************************************************
        public IActionResult Delete_M(int? Id)
        {
            if (Id == null || Id == 0)
            {
                return NotFound();
            }
            var obj = _context.Mummy_N_Me.Find(Id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete_M(Mummy_n_Me_P member)
        {
            _context.Mummy_N_Me.Remove(member);
            _context.SaveChanges();
            return RedirectToAction("Mummy_N");
        }
    }
}
