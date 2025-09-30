namespace hasib_Playon24WebApi.Models
{
    public class AttendanceSummaryDto
    {
        public int EmployeeID { get; set; }
        public string? Name { get; set; }
        public string? DepartmentName { get; set; }
        public int PresentCount { get; set; }
        public int AbsentCount { get; set; }
    }
}
