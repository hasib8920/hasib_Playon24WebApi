namespace hasib_Playon24WebApi.Models
{
    public class AddEmployeeRequest
    {
        public string Name { get; set; } = null!;
        public int? DepartmentID { get; set; }
        public DateTime JoinDate { get; set; }
        public decimal Salary { get; set; }
    }
}
