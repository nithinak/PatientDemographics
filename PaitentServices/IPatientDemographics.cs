using System;
using System.Collections.Generic;
using System.Text;

namespace PaitentServices
{
    /// <summary>
    /// Inteface to define the methods
    /// </summary>
    interface IPatientDemographics
    {

        List<BusinessEntity.PatientDetails> GetPatientDetails();
        void SavePatientDetails(Object patientDetails);
    }
}
