using System.ComponentModel.DataAnnotations;

namespace HospitalCaseStudy.Models
{
    public class MedicalRecordModel:CommonModel
    {
        [Required,StringLength(500)]
        public string Diagnoses {  get; set; }
        [Required,StringLength(1000)]
        public string Prescription { get; set; }
        [StringLength(1000)]
        public string Notes { get; set; }
        public int AppointmentId { get; set; }
        public AppointmentModel Appointment { get; set; }
        
    }
}
