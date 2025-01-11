using Appointments.Framework.Settings;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Options;

namespace Appointments.API;

/// <summary>
/// Authentication attribute to exert the endpoint to require Authorization header, defaults Authorization and ApiKey header
/// </summary>
[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = false, AllowMultiple = false)]
public class ApiKeyFilterAttribute : Attribute, IAuthorizationFilter
{
    #region Fields
    private ILogger _logger;
    private AuthSettings _authSettings;
    #endregion

    #region Public Methods        
    /// <summary>
    /// Called early in the filter pipeline to confirm request is authorized.
    /// </summary>
    /// <param name="context">The <see cref="T:Microsoft.AspNetCore.Mvc.Filters.AuthorizationFilterContext" />.</param>
    public void OnAuthorization(AuthorizationFilterContext context)
    {
        SetServices(context);

        //string apiKey = context.HttpContext.Request.Headers["ApiKey"].ToString();


    }
    #endregion

    #region Private Methods
    /// <summary>
    /// Sets context services, which cannot be set in constructor due to implementation
    /// </summary>
    /// <param name="context"></param>
    private void SetServices(AuthorizationFilterContext context)
    {
        ILoggerFactory loggerFactory = context.HttpContext.RequestServices.GetService<ILoggerFactory>();
        _logger = loggerFactory.CreateLogger<ApiKeyFilterAttribute>();

        _authSettings = context.HttpContext.RequestServices.GetService<IOptions<AuthSettings>>().Value;
    }
    #endregion
}
