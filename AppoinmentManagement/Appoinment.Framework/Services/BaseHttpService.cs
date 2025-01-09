using Identity.Http.Extensions;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace Appoinments.Framework.Services;

/// <summary>
/// The base http client service used to send requests to other StoreMate Connect APIs
/// </summary>
public class BaseHttpService
{
    /// <summary>
    /// Initializes a new instance of the <see cref="BaseHttpService" /> class.
    /// </summary>
    /// <param name="httpClient">The HTTP client.</param>
    /// <param name="identityContext">The identity context.</param>
    public BaseHttpService(HttpClient httpClient,
        IIdentityContext identityContext)
    {
        HttpClient = httpClient;
        IdentityContext = identityContext;
    }

    /// <summary>Gets the HTTP client.</summary>
    /// <value>The HTTP client.</value>
    protected HttpClient HttpClient { get; }

    /// <summary>Gets the identity context.</summary>
    /// <value>The identity context.</value>
    protected IIdentityContext IdentityContext { get; }

    /// <summary>Sends the request asynchronous.</summary>
    /// <typeparam name="T">The expected response of the Http call</typeparam>
    /// <param name="data">The data.</param>
    /// <param name="url">The URL.</param>
    /// <param name="httpMethod">The HTTP method.</param>
    /// <returns>
    /// The http response content deserialized as the typed paramater
    /// </returns>
    /// <exception cref="UnauthorizedException">When the token in the identity context is expired or invalid</exception>
    /// <exception cref="ValidationException">If the request has failed and returned with a non successful status code</exception>
    public async Task<T> SendAsync<T>(object data, string url, HttpMethod httpMethod)
    {
        string authHeader = IdentityContext.AuthorizationHeader;
        string authScheme = IdentityContext.AuthorizationScheme;

        string json = JsonSerializer.Serialize(data);

        var httpContent = new StringContent(json, Encoding.UTF8, "application/json");

        var request = new HttpRequestMessage(httpMethod, url);

        if (!string.IsNullOrEmpty(authHeader) && !string.IsNullOrEmpty(authScheme))
        {
            request.Headers.Authorization =
               new AuthenticationHeaderValue(authScheme, authHeader);
        }

        request.Content = httpContent;

        HttpResponseMessage response = await HttpClient.SendAsync(request);

        if (response.StatusCode == HttpStatusCode.Unauthorized)
            throw new UnauthorizedAccessException();
        else if (!response.IsSuccessStatusCode)
            throw new ValidationException(await response.Content.ReadAsStringAsync());

        string stringResult = await response.Content.ReadAsStringAsync();

        var options = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        };

        T result = JsonSerializer.Deserialize<T>(stringResult, options);

        return result;
    }

    /// <summary>Sends the request asynchronous.</summary>
    /// <param name="data">The data.</param>
    /// <param name="url">The URL.</param>
    /// <param name="httpMethod">The HTTP method.</param>
    /// <returns>
    /// The http response content deserialized as the typed paramater
    /// </returns>
    /// <exception cref="UnauthorizedException">When the token in the identity context is expired or invalid</exception>
    /// <exception cref="ValidationException">If the request has failed and returned with a non successful status code</exception>
    public async Task SendAsync(object data, string url, HttpMethod httpMethod)
    {
        string authHeader = IdentityContext.AuthorizationHeader;
        string authScheme = IdentityContext.AuthorizationScheme;

        string json = JsonSerializer.Serialize(data);

        var httpContent = new StringContent(json, Encoding.UTF8, "application/json");

        var request = new HttpRequestMessage(httpMethod, url);

        if (!string.IsNullOrEmpty(authHeader) && !string.IsNullOrEmpty(authScheme))
        {
            request.Headers.Authorization =
               new AuthenticationHeaderValue(authScheme, authHeader);
        }

        request.Content = httpContent;

        HttpResponseMessage response = await HttpClient.SendAsync(request);

        if (response.StatusCode == HttpStatusCode.Unauthorized)
            throw new UnauthorizedAccessException();

        else if (!response.IsSuccessStatusCode)
            throw new ValidationException(await response.Content.ReadAsStringAsync());
    }

    /// <summary>Gets the asynchronous.</summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="url">The URL.</param>
    /// <returns>The desrialized response object</returns>
    /// <exception cref="UnauthorizedException">When the token is expired</exception>
    /// <exception cref="ValidationException">When the request fiales</exception>
    public async Task<T> GetAsync<T>(string url)
    {
        string authHeader = IdentityContext.AuthorizationHeader;
        string authScheme = IdentityContext.AuthorizationScheme;

        var request = new HttpRequestMessage(HttpMethod.Get, url);

        if (!string.IsNullOrEmpty(authHeader) && !string.IsNullOrEmpty(authScheme))
        {
            request.Headers.Authorization =
               new AuthenticationHeaderValue(authScheme, authHeader);
        }

        HttpResponseMessage response = await HttpClient.SendAsync(request);

        if (response.StatusCode == HttpStatusCode.Unauthorized)
            throw new UnauthorizedAccessException();
        else if (!response.IsSuccessStatusCode)
            throw new ValidationException(await response.Content.ReadAsStringAsync());

        string stringResult = await response.Content.ReadAsStringAsync();

        var options = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        };

        T result = JsonSerializer.Deserialize<T>(stringResult, options);

        return result;
    }
}