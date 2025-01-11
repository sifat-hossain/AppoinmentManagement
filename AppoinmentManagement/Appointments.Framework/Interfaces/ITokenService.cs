using Base.Domain;

namespace Appointments.Framework.Interfaces
{
    public interface ITokenService
    {
        /// <summary>
        /// Generates JWT token for user
        /// </summary>
        /// <param name="user">User entity</param>
        /// <returns>New JWT token</returns>
        string GenerateToken(ITokenable user);

    }
}