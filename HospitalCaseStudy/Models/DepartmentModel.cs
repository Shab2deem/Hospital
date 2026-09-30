using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace HospitalCaseStudy.Models
{
    public class DepartmentModel:CommonModel
    {
        [StringLength(150)]
        public string? Location { get; set; }
        public ICollection<DoctorModel> Doctors { get; set; }
    }
}
