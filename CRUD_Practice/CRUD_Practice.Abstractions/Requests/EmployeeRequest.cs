namespace CRUD_Practice.Abstractions.Requests
{
    public class EmployeeRequest
    {
        public string Name { get; set; } = null!;
        public int DepartmentId { get; set; }
        public decimal Salary { get; set; }
        public DateTime JoiningDate { get; set; }
    }
}
