namespace Appointments.Application.Actions;

/// <summary>
/// Base response for the store mate api
/// </summary>
public class AppointmentResponse
{
    /// <summary>
    /// Gets or sets a value indicating whether this instance is successful.
    /// </summary>
    /// <value>
    /// <c>true</c> if this instance is successful; otherwise, <c>false</c>.
    /// </value>
    public bool IsSuccessful { get; set; }

    /// <summary>Gets or sets the message of the creat result.</summary>
    /// <value>The message.</value>
    public string? Message { get; set; }

}

/// <summary>
/// Base generic response for the store mate api
/// </summary>
/// <typeparam name="T">Response model</typeparam>
public class AppointmentResponse<T> : AppointmentResponse where T : class
{
    /// <summary>
    /// Generic response 
    /// </summary>
    public T Model { get; set; }
}

