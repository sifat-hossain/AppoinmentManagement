using System.Linq.Expressions;
using Users.Domain.Entities;

namespace Users.Application.Actions.Users;

/// <summary>
/// Represents model for creating a user
/// </summary>
public class UserModel
{
    #region Properties

    /// <summary>
    /// User's username
    /// </summary>
    public string UserName { get; set; }

    /// <summary>
    /// User's Password
    /// </summary>
    public string Password { get; set; }

    #endregion

    public static Expression<Func<User, UserModel>> Projection
    {
        get
        {
            return user => new UserModel
            {
                UserName = user.UserName,
                Password = user.Password
            };
        }
    }

    public static UserModel Create(User entity)
    {
        return Projection.Compile().Invoke(entity);
    }
}