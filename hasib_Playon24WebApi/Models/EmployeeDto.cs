namespace hasib_Playon24WebApi.Models
{
    public class EmployeeDto
    {
        public int EmployeeID { get; set; }
        public string Name { get; set; }
        public int? DepartmentID { get; set; }
        public string DepartmentName { get; set; }
        public DateTime JoinDate { get; set; }
        public decimal Salary { get; set; }
    }
}
