﻿using Microsoft.AspNetCore.Mvc;

namespace GeeksProject02.Controllers
{
    public class VaccineController : Controller
    {
        //private object IDNumberTextBox;
        //private object DateOfBirthTextBox;

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Vaccine()
        {
            return View();
        }
        

    }

}
