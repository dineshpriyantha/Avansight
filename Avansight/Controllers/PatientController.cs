using Avansight.Domain;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Avansight.Controllers
{
    public class PatientController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult AddPatient(string jsonInput = "")
        {
            Patient patient = new Patient
            {
                Age = 25
            };

            return Json(patient);
        }
    }
}
