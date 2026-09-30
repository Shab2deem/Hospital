using System.ComponentModel.DataAnnotations;

namespace HospitalCaseStudy.Models
{
    public class PatientModel:CommonModel
    {
        [Required]
        public string Gender {  get; set; }
        [Required]
        public DateTime DateOfBirth {  get; set; }
        [Required, Phone, MaxLength(20)]
        public string Phone {  get; set; }
        [MaxLength(20)]
        public string Address { get; set; }
        public ICollection<AppointmentModel> Appointments { get; set; }


    }
}
