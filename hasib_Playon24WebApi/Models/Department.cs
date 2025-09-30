using System.ComponentModel.DataAnnotations;

namespace hasib_Playon24WebApi.Models
{
    public class Department
    {
        [Key]
        public int DepartmentID { get; set; }

        [Required]
        [MaxLength(100)]
        public string DepartmentName { get; set; }
    }
}
