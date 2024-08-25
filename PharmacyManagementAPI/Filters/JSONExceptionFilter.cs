using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Text.Json;

namespace PharmacyManagementAPI.Filters
{
    public class JsonExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            if (context.Exception is JsonException)
            {
                context.Result = new BadRequestObjectResult(new { error = "Invalid JSON format." });
                context.ExceptionHandled = true;
            }
        }
    }
}
