using System.ComponentModel.DataAnnotations;

namespace PatientDemographics.Models
{
    public class PatientDetails
    {
        
       
        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Forenames { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 3)]
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
    public class CreatePatientDetails
    {
        [Required(ErrorMessage = "ForeName Required")]
        [StringLength(50, MinimumLength = 3)]
        public string ForeName { get; set; }
        [Required(ErrorMessage ="Surname Required")]
        [StringLength(50, MinimumLength = 3)]
        public string Surname { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public string DOB { get; set; }
        public string Gender { get; set; }
        public string Home { get; set; }
        public string Work { get; set; }
        public string Mobile { get; set; }

    }

}