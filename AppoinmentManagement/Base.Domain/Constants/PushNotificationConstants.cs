namespace Base.Domain.Constants;

/// <summary>
/// Static class for holding constants used by the framework for handeling
/// push notifications
/// </summary>
public static class PushNotificationConstants
{
    #region Constants
    /// <summary>
    /// Constant used to pull operation
    /// </summary>
    public const string PULL_NOTIFICATION_KEY = "pull";

    /// <summary>
    /// Constant used to push operation
    /// </summary>
    public const string PUSH_NOTIFICATION_KEY = "push";

    /// <summary>
    /// Constant used to overwrite operation
    /// </summary>
    public const string OVERWRITE_NOTIFICATION_KEY = "overwrite";

    /// <summary>
    /// Constant used to overwrite operation
    /// </summary>
    public const string CLEAR_SYNC_DETAILS_NOTIFICATION_KEY = "clearsync";

    /// <summary>
    /// Constant used to overwrite operation
    /// </summary>
    public const string DELETE_NOTIFICATION_KEY = "delete";

    /// <summary>
    /// Constant for the delimiting charater for the notification payload
    /// </summary>
    public const char NOTIFICATION_PAYLOAD_DELIMITER = ':';

    /// <summary>
    /// Constant for the delimiting charater for the
    /// notification payload data element
    /// </summary>
    public const char NOTIFICATION_DATA_DELIMITER = '|';
    #endregion Constants
}