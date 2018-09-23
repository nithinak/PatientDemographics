using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Xml.Linq;
using System.Xml.Serialization;
using System.IO;
using System.Xml;
using PatientDemographics.Models;
using PaitentServices;

namespace PatientDemographics.Controllers
{
    public class PatientDemoGraphicController : ApiController
    {
        /// <summary>
        /// patientServices Private Object of PatientServices
        /// </summary>
        private readonly PatientServices patientServices = new PatientServices();
        /// <summary>
        /// Get the Personal Details of Patients from the DataBase.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IHttpActionResult GetPatientPersonalDetails()
        {
            List<PatientDetails> patientDetails = new List<PatientDetails>();
            var result = patientServices.GetPatientDetails().ToList();


            if (result == null)
            {
                return BadRequest();
            }
            else
            {
                foreach (var item in result)
                {
                    var PatientInfo = new PatientDetails()
                    {
                        Forenames = item.Forenames,
                        Surname = item.Surname,
                        DOB = item.DOB,
                        Gender = item.Gender,
                        Telephone = new Telephone()
                        {
                            Home = item.Telephone.Home,
                            Work = item.Telephone.Work,
                            Mobile = item.Telephone.Mobile

                        }

                        //Telephone = result.Select(x => x.Telephone)
                    };
                    patientDetails.Add(PatientInfo);


                }
                return Ok(patientDetails);
            }

        }
        /// <summary>
        /// Save the Patient Personal Data into the Database
        /// </summary>
        /// <param name="patientDetails"></param>
        /// <returns></returns>
        [HttpPost]
        public IHttpActionResult SavePatientDetails(PatientDetails patientDetails)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Not a Valid Model");

            }
            else
            {

                patientServices.SavePatientDetails(patientDetails);
                return Ok();
            }


        }

    }
}
