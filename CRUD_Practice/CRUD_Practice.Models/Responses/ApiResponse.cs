namespace CRUD_Practice.Models.Responses
{
    public class ApiResponse<T>
    {
        public int Status { get; set; }
        public string Message { get; set; } = string.Empty;
        public T? Data { get; set; }

        public static ApiResponse<T> SuccessResponse(string message, int statusCode)
        {
            return new ApiResponse<T>
            {
                Status = statusCode,
                Message = message,
                Data = CreateDefaultData()
            };
        }

        public static ApiResponse<T> SuccessResponse(T data, string message = "Request successful", int statusCode = 200)
        {
            data ??= CreateDefaultData();

            return new ApiResponse<T>
            {
                Status = statusCode,
                Message = message,
                Data = data
            };
        }

        public static ApiResponse<T> ErrorResponse(string message = "Error", int statusCode = 400)
        {
            var response = new ApiResponse<T>
            {
                Status = statusCode,
                Message = message,
                Data = CreateDefaultData(),
            };

            return response;
        }

        private static T CreateDefaultData()
        {
            var type = typeof(T);

            if (type == typeof(string))
            {
                return (T)(object)string.Empty;
            }

            if (type.IsGenericType &&
                typeof(System.Collections.IEnumerable).IsAssignableFrom(type))
            {
                var itemType = type.GetGenericArguments()[0];
                var listType = typeof(List<>).MakeGenericType(itemType);
                return (T)Activator.CreateInstance(listType)!;
            }

            // For arrays
            if (type.IsArray)
            {
                var elementType = type.GetElementType()!;
                return (T)(object)Array.CreateInstance(elementType, 0);
            }

            // Special case for object
            if (type == typeof(object))
            {
                return (T)(object)Array.Empty<object>();
            }

            return default!;
        }

    }
}
