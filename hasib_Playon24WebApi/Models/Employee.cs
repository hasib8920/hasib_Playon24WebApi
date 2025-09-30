using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace hasib_Playon24WebApi.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeID { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        // DepartmentID can be NULL (your DB allows it)
        public int? DepartmentID { get; set; }
        public Department? Department { get; set; }

        [Required]
        [Column(TypeName = "date")]
        public DateTime JoinDate { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Salary { get; set; }
    }
}
