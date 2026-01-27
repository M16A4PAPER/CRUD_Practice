using System.Security.Claims;

namespace CRUD_Practice.WebAPI.Middleware
{
    public class SerilogRequestEnricherMiddleware
    {
        //To process the Http Request
        private readonly RequestDelegate _next;

        public SerilogRequestEnricherMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            // Get client IP
            //var clientIp = context.Connection.RemoteIpAddress?.ToString() ?? "unknown";

            // Get request info
            var method = context.Request.Method;
            var path = context.Request.Path;

            // Get user ID from claims (if logged in)
            var userId = context.User?.FindFirst(ClaimTypes.Email)?.Value ?? "anonymous";

            // Push properties into Serilog context
            using (Serilog.Context.LogContext.PushProperty("UserId", userId))
            //using (Serilog.Context.LogContext.PushProperty("ClientIP", clientIp))
            using (Serilog.Context.LogContext.PushProperty("RequestMethod", method))
            using (Serilog.Context.LogContext.PushProperty("RequestPath", path))
            {
                await _next(context); // call next middleware
            }
        }
    }

}
