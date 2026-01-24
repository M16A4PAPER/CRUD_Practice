namespace CRUD_Practice.Models.Responses
{
    public class EmployeeResponse
    {
        public int? employee_id { get; set; }
        public string? employee_name { get; set; }
        public int? department_id { get; set; }
        public string? department_name { get; set; }
        public decimal? employee_salary { get; set; }
        public DateTime? join_date { get; set; }
    }
}
