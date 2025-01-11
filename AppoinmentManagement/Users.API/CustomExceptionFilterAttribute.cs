using Appointments.Framework.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;
using System.Security.Authentication;

namespace Users.API;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
public class CustomExceptionFilterAttribute : ExceptionFilterAttribute
{
    private readonly ILogger<CustomExceptionFilterAttribute> _logger;

    public CustomExceptionFilterAttribute(ILogger<CustomExceptionFilterAttribute> logger)
    {
        _logger = logger;
    }

    public override void OnException(ExceptionContext context)
    {
        if (context.Exception is ValidationException exception)
        {
            context.HttpContext.Response.ContentType = "application/json";
            context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            context.Result = new JsonResult(exception.Failures);

            return;
        }

        if (context.Exception is AuthenticationException authenticationException)
        {
            context.HttpContext.Response.ContentType = "application/json";
            context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            context.Result = new JsonResult(new { message = authenticationException.Message });

            return;
        }

        if (context.Exception is UnauthorizedException unauthorizedException)
        {
            context.HttpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
            context.Result = new UnauthorizedObjectResult(new { message = unauthorizedException.Message });

            return;
        }

        if (context.Exception is ForbiddenException)
        {
            context.Result = new ForbidResult();

            return;
        }

        if (context.Exception is NotFoundException)
        {
            context.Result = new NotFoundResult();

            return;
        }

        HttpStatusCode code = HttpStatusCode.InternalServerError;

        context.HttpContext.Response.ContentType = "application/json";
        context.HttpContext.Response.StatusCode = (int)code;
#if DEBUG
        context.Result = new JsonResult(new
        {
            error = new[] { context.Exception.Message },
            stackTrace = context.Exception.StackTrace
        });
#endif
    }
}
