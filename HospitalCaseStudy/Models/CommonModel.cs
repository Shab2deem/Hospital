using System.ComponentModel.DataAnnotations;

namespace HospitalCaseStudy.Models
{
    public class CommonModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Name  { get; set; }
    }
}
