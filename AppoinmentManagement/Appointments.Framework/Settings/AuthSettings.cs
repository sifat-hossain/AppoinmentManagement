namespace Appointments.Framework.Settings;

public class AuthSettings
{
    /// <summary>
    /// The signing key value
    /// </summary>
    public string SigningKey { get; set; }

    /// <summary>
    /// The Issuer value
    /// </summary>
    public string Issuer { get; set; }

    /// <summary>
    /// The Audience value
    /// </summary>
    public string Audience { get; set; }

    /// <summary>
    /// The number of minutes of the jwt token lifetime, after that time jwt bearer token gets expired
    /// </summary>
    public int LifetimeMinutes { get; set; }

    /// <summary>
    /// The number of months of the refresh token lifetime, after that time refresh token gets expired
    /// </summary>
    public int LifetimeMonths { get; set; }

    /// <summary>
    /// Count of max login attempts
    /// </summary>
    public int LoginAttempts { get; set; }

    /// <summary>
    /// Suspended user from login time in minutes
    /// </summary>
    public int SuspendedTime { get; set; }
}
