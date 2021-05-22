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
        private List<Patient> listOfPatients = new List<Patient>();

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
            //int noOfMales = 0;
            //int noOfFemales = 0;
            int noOfMales = (maleWeight * sampleSize / (maleWeight + femaleWeight)) ;
            int noOfFemales = sampleSize - noOfMales;

            int noOfMalesin2130ageRange = ageGroup2130 * noOfMales / (ageGroup2130 + totalNoOfPatientInEachAgeRange);
            int noOfFemaleIn2130agerange = ageGroup2130 * noOfFemales / (ageGroup2130 + totalNoOfPatientInEachAgeRange);

            int noOfMalesin3140ageRange = ageGroup3140 * noOfMales / (ageGroup3140 + totalNoOfPatientInEachAgeRange);
            int noOfFemaleIn3140agerange = ageGroup3140 * noOfFemales / (ageGroup3140 + totalNoOfPatientInEachAgeRange);

            int noOfMalesin4150ageRange = ageGroup4150 * noOfMales / (ageGroup4150 + totalNoOfPatientInEachAgeRange);
            int noOfFemaleIn4150agerange = ageGroup4150 * noOfFemales / (ageGroup4150 + totalNoOfPatientInEachAgeRange);

            int noOfMalesin5160ageRange = ageGroup5160 * noOfMales / (ageGroup5160 + totalNoOfPatientInEachAgeRange);
            int noOfFemaleIn5160agerange = ageGroup5160 * noOfFemales / (ageGroup5160 + totalNoOfPatientInEachAgeRange);
                        
            ListOfMalePatient(noOfMalesin2130ageRange, "M", 21, 30);
            ListOfMalePatient(noOfMalesin3140ageRange, "M", 31, 40);
            ListOfMalePatient(noOfMalesin4150ageRange, "M", 41, 50);
            ListOfMalePatient(noOfMalesin5160ageRange, "M", 51, 60);

            ListOfMalePatient(noOfFemaleIn2130agerange, "F", 21, 30);
            ListOfMalePatient(noOfFemaleIn3140agerange, "F", 31, 40);
            ListOfMalePatient(noOfFemaleIn4150agerange, "F", 41, 50);
            ListOfMalePatient(noOfFemaleIn5160agerange, "F", 51, 60);


            // Unit of work

            return Json(listOfPatients);
        }


        /// <summary>
        /// List Of Patient
        /// </summary>
        /// <param name="noOfPatients"></param>
        /// <param name="gender"></param>
        /// <param name="min"></param>
        /// <param name="max"></param>
        private void ListOfMalePatient(int noOfPatients, string gender, int min, int max)
        {
            for (int i = 0; i < noOfPatients; i++)
            {
                Patient patient = new Patient();
                patient.Age = GetRandomNumber(min, max);
                patient.Gender = gender;
                listOfPatients.Add(patient);
            }
        }

        /// <summary>
        /// Get Random Number
        /// </summary>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        private int GetRandomNumber(int min, int max)
        {
            lock (getrandom)
            {
                return getrandom.Next(min, max);
            }
        }
    }
}
