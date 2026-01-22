namespace CRUD_Practice.Abstractions.Requests
{
    public class EmployeeRequest
    {
        public string Name { get; init; } = null!;
        public int DepartmentId { get; init; }
        public decimal Salary { get; init; }
        public DateTime JoiningDate { get; init; }
    }
}
