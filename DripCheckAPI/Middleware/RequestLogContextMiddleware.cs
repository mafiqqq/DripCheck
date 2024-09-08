using Serilog.Context;

namespace DripCheckAPI.Middleware
{
    public class RequestLogContextMiddleware
    {
        private readonly RequestDelegate _next;

        public RequestLogContextMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        // Purpose: Pushing the CorrelationId property into the Context which makes it available for structured log
        // Available in life cycle of this HttpRequest
        public Task InvokeAsync(HttpContext context) 
        {
            using (LogContext.PushProperty("CorrelationId", context.TraceIdentifier))
            { 
                return _next(context);
            }
        }
    }
}
