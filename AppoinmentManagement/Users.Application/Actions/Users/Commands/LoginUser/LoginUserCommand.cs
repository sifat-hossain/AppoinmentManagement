using Users.Application.Actions.Users;

namespace Users.Application.Actions.Users.Commands.LoginUser;

/// <summary>
/// Represents model for logging in
/// </summary>
public class LoginUserCommand : IRequest<UserTokenModel>
{
    /// <summary>
    /// Users username
    /// </summary>
    public string UserName { get; set; }

    /// <summary>
    /// Users password
    /// </summary>
    public string Password { get; set; }
}