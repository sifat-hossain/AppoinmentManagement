namespace Users.Application.Actions.Users.Commands.CreateUser;

/// <summary>
/// Represents model for creating a user
/// </summary>
public class CreateUserCommand : IRequest<UserModel>
{
    /// <summary>
    /// User username
    /// </summary>
    public string UserName { get; set; }

    /// <summary>
    /// User password
    /// </summary>
    public string Password { get; set; }
}