using System;
using System.Collections.Generic;

namespace BusinessEntity
{
    
    public class PatientDetails
    {
        
        public int ID { get; set; }
        public string Forenames { get; set; }
        public string Surname { get; set; }
        public string DOB { get; set; }
        public string Gender { get; set; }
        public Telephone Telephone { get; set; }
    }

    public class Telephone
    {
        public string Home { get; set; }
        public string Work { get; set; }
        public string Mobile { get; set; }
        
    }

}
