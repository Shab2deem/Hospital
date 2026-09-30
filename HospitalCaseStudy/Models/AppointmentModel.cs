using System.ComponentModel.DataAnnotations;

namespace HospitalCaseStudy.Models
{
    public class AppointmentModel:CommonModel
    {
        [Required]
        public DateTime AppointmentDate {  get; set; }
        [Required,MaxLength(30)]
        public string Status { get; set; }
        [Required]
        public int DoctorId { get; set; }
        public DoctorModel Doctor { get; set; }
        [Required]
        public int PatientId { get; set; }
        public PatientModel Patient { get; set; }
        public MedicalRecordModel MedicalRecord { get; set; }
    }
}
