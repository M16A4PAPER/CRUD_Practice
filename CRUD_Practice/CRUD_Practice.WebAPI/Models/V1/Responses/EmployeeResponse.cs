namespace CRUD_Practice.WebAPI.Models.V1.Responses
{
    public class EmployeeResponse
    {
        public int? employee_id { get; init; }
        public string? employee_name { get; init; }
        public int? department_id { get; init; }
        public string? department_name { get; init; }
        public decimal? employee_salary { get; init; }
        public DateTime? join_date { get; init; }
    }
}
