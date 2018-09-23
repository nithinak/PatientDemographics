using PatientDemographics.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace PatientDemographics.Controllers
{

    public class HomeController : Controller
    {
        /// <summary>
        /// Action method to fetch the Data Using WebApi
        /// </summary>
        /// <returns>Status Code Ok with 200 PatientDetails</returns>
        public ActionResult Index()
        {
            IEnumerable<PatientDetails> patientDetails = null;
            using (var Clinet = new HttpClient())
            {
                Clinet.BaseAddress = new Uri("http://localhost:58080/api/PatientDemoGraphic/");
                //HTTP GET
                var responseTask = Clinet.GetAsync("patientDetails");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<PatientDetails>>();
                    readTask.Wait();

                    patientDetails = readTask.Result;
                }
            }

            return View(patientDetails);
        }
        public ActionResult Create()
        {
            return View();
        }
        /// <summary>
        /// Create a new patient persoanl information
        /// </summary>
        /// <param name="createPatientDetails"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult create(CreatePatientDetails createPatientDetails)
        {
            if (ModelState.IsValid)
            {
                var PatientDetails = new PatientDetails()
                {
                    Forenames = createPatientDetails.ForeName,
                    Surname = createPatientDetails.Surname,
                    DOB = createPatientDetails.DOB,
                    Gender = createPatientDetails.Gender,
                    Telephone = new Telephone()
                    {
                        Home = createPatientDetails.Home,
                        Work = createPatientDetails.Work,
                        Mobile = createPatientDetails.Mobile

                    }
                };
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:58080/api/PatientDemoGraphic/");

                    //HTTP POST
                    var postTask = client.PostAsJsonAsync<PatientDetails>("patientDetails", PatientDetails);
                    postTask.Wait();

                    var result = postTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Index");
                    }
                }
               

                return View(PatientDetails);

            }
            else
            {
                ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");

                return View();
            }

           
        }
    }
}
