using System;
using System.Collections.Generic;
using System.Text;

namespace PaitentServices
{
    interface IPatientDemographics
    {

        List<BusinessEntity.PatientDetails> GetPatientDetails();
        void SavePatientDetails(Object patientDetails);
    }
}
