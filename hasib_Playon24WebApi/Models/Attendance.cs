using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace hasib_Playon24WebApi.Models
{
    public class Attendance
    {
        [Key]
        public int AttendanceID { get; set; }

        [Required]
        public int EmployeeID { get; set; }
        public Employee Employee { get; set; }

        [Required]
        [Column(TypeName = "date")]
        public DateTime AttendanceDate { get; set; }

        [Required]
        [MaxLength(10)]
        public string Status { get; set; }
    }
}
