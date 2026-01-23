namespace CRUD_Practice.Abstractions.Requests
{
    public class DepartmentRequest
    {
        public string Name { get; init; } = string.Empty;
        public string? Location { get; init; }
    }
}
