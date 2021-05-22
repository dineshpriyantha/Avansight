using Avansight.Domain;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
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

        /// <summary>
        /// Add Patient Json data to db
        /// </summary>
        /// <param name="jsonInput"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult AddPatient(string jsonInput = "")
        {
            // Handling a stringified JS object
            dynamic dynObj = JsonConvert.DeserializeObject(jsonInput);
            int sampleSize = dynObj.sampleSize;
            int maleWeight = dynObj.maleWeight;
            int femaleWeight = dynObj.femaleWeight;

            Patient patient = new Patient
            {
                Age = 25
            };

            return Json(patient);
        }
    }
}
