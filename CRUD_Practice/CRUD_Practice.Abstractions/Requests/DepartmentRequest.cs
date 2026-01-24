namespace CRUD_Practice.Abstractions.Requests
{
    public class DepartmentRequest
    {
        public string Name { get; set; } = string.Empty;
        public string? Location { get; set; }
    }
}
