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
        private static readonly Random getrandom = new Random();
        private readonly IDapper _dapper;

        //public PatientController(IDapper dapper)
        //{
        //    _dapper = dapper;
        //}

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
            int ageGroup2130 = dynObj.ageGroup2130;
            int ageGroup3140 = dynObj.ageGroup3140;
            int ageGroup4150 = dynObj.ageGroup4150;
            int ageGroup5160 = dynObj.ageGroup5160;

            int totalNoOfPatientInEachAgeRange = ageGroup2130 + ageGroup3140 + ageGroup4150 + ageGroup5160;

            //  logic to generate records.
            int noOfMales = 0;
            int noOfFemales = 0;
            noOfMales = (maleWeight / (maleWeight + femaleWeight)) * sampleSize;
            noOfFemales = sampleSize - noOfMales;

            int noOfMalesin2130ageRange = (ageGroup2130 / (ageGroup2130 + totalNoOfPatientInEachAgeRange)) * noOfMales;
            int noOfFemaleIn2130agerange = (ageGroup2130 / (ageGroup2130 + totalNoOfPatientInEachAgeRange)) * noOfFemales;

            int noOfMalesin3140ageRange = (ageGroup3140 / (ageGroup3140 + totalNoOfPatientInEachAgeRange)) * noOfMales;
            int noOfFemaleIn3140agerange = (ageGroup3140 / (ageGroup3140 + totalNoOfPatientInEachAgeRange)) * noOfFemales;

            int noOfMalesin4150ageRange = (ageGroup4150 / (ageGroup4150 + totalNoOfPatientInEachAgeRange)) * noOfMales;
            int noOfFemaleIn4150agerange = (ageGroup4150 / (ageGroup4150 + totalNoOfPatientInEachAgeRange)) * noOfFemales;

            int noOfMalesin5160ageRange = (ageGroup5160 / (ageGroup5160 + totalNoOfPatientInEachAgeRange)) * noOfMales;
            int noOfFemaleIn5160agerange = (ageGroup5160 / (ageGroup5160 + totalNoOfPatientInEachAgeRange)) * noOfFemales;

            List<Patient> patients = new List<Patient>();

            


            GetRandomNumber(21, 30);

            // editing...
            Patient patient = new Patient
            {
                Age = 25
            };

            return Json(patient);
        }

        private int GetRandomNumber(int min, int max)
        {
            lock(getrandom)
            {
                return getrandom.Next(min, max);
            }
        }

        private void ListOfMalePatient(int noOfMales)
        {
            List<Patient> patients = new List<Patient>();
            Patient patient = new Patient();
            for (int i = 0; i < noOfMales; i++)
            {
               // patients.Add(patient.Age)
            }
        }
    }
}
