namespace CRUD_Practice.Models.Models
{
    public class Employee
    {
        public int Id { get; init; }
        public string Name { get; init; } = string.Empty;
        public int? DepartmentId { get; init; }   // nullable for LEFT JOIN
        public string? DepartmentName { get; init; }
        public decimal Salary { get; init; }
        public DateTime JoiningDate { get; init; }
    }
}
