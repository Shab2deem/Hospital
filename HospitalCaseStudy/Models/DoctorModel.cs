using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Contracts;
using Microsoft.EntityFrameworkCore;

namespace HospitalCaseStudy.Models
{
    [Index("Email",IsUnique =true)]
    public class DoctorModel:CommonModel
    {
        [Required]
        public string Specialization {  get; set; }
        [EmailAddress]
        [Required]
        public string Email { get; set; }
        
        [Phone,Required]
        public string Phone {  get; set; }
        [Required]
        public decimal Salary { get; set; }
        [Required]
        public int DepartmentId { get; set; }
        public DepartmentModel Department { get; set; }

        public ICollection<AppointmentModel> Appointments { get; set; }

    }
}
