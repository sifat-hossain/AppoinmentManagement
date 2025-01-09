using Appoinments.Framework.Interfaces;
using Appoinments.Framework.Settings;
using Base.Domain;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Appoinments.Framework.Services;

/// <summary>
/// ITokenService implementation
/// </summary>
public class TokenService : ITokenService
{
    /// <summary>
    /// The authentication settings
    /// </summary>
    private readonly AuthSettings _authSettings;
    /// <summary>The random generator</summary>
    private readonly Random _random;

    /// <summary>The alphanumeric chars</summary>
    private const string Chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

    public TokenService(IOptions<AuthSettings> authSettings)
    {
        _authSettings = authSettings.Value;
        _random = new Random();
    }

    /// <summary>
    /// Generates new JWT token for the user
    /// </summary>
    /// <param name="user">User entity</param>
    /// <returns>new JWT token</returns>
    public string GenerateToken(ITokenable user)
    {
        string guid = Guid.NewGuid().ToString();

        var claims = new List<Claim>
        {
            new Claim(JwtRegisteredClaimNames.Jti, guid),
            new Claim(ClaimTypes.Name, user.UserName)
        };
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_authSettings.SigningKey));

        var jwt = new JwtSecurityToken(
            issuer: _authSettings.Issuer,
            audience: _authSettings.Audience,
            claims: claims,
            notBefore: DateTime.UtcNow,
            expires: DateTime.UtcNow.AddMinutes(_authSettings.LifetimeMinutes),
            signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256)
        );

        string accessToken = new JwtSecurityTokenHandler().WriteToken(jwt);

        return accessToken;
    }
}
