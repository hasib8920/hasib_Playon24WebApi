namespace hasib_Playon24WebApi.Models
{
    public class AddAttendanceRequest
    {
        public int EmployeeID { get; set; }
        public DateTime AttendanceDate { get; set; }
        public string Status { get; set; } = null!;
    }
}
