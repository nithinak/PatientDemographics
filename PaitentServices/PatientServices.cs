﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessEntity;
using PatientDataAccess;

namespace PaitentServices
{
    public class PatientServices : IPatientDemographics
    {
        public List<PatientDetails> GetPatientDetails()
        {
            List<PatientDetails> patientDetails = new List<PatientDetails>();
            using (PatientDemographicsEntities db = new PatientDemographicsEntities())
            {
                var data = db.PatientDetails.ToList();


                var result = from a in data
                            select new
                            {
                                ID = a.Id,
                                PatientInfo = a.PatientDetails
                            };
                foreach (var item in result)
                {
                    Object objPatientInfo = PatientHelper.ObjectToXML(item.PatientInfo, typeof(PatientDetails));
                    patientDetails.Add((PatientDetails)objPatientInfo);
                }





            }
            return patientDetails;

        }

        public void SavePatientDetails(Object patientDetails )
        {
            using (PatientDemographicsEntities db = new PatientDemographicsEntities())
            {
                
              var result=  PatientHelper.GetXMLFromObject(patientDetails);
                db.usersp_InsertPersonalDetails(result);
            }

        }
    }
}
