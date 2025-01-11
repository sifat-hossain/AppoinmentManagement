using Appointments.Framework.Interfaces;
using Appointments.Framework.Settings;
using Users.Domain.Entities;
using static BCrypt.Net.BCrypt;


namespace Users.Application.Actions.Users.Commands.LoginUser
{
    /// <summary>
    /// Represents logic for Login User Command
    /// </summary>
    public class LoginUserHandler : IRequestHandler<LoginUserCommand, UserTokenModel>
    {
        private readonly IUserDbContext _userDbContext;
        private readonly AuthSettings _authSettings;
        // private readonly IDateTime _dateTime;
        private readonly ITokenService _tokenService;

        public LoginUserHandler(IUserDbContext userDbContext,
            IOptions<AuthSettings> options,
            // IDateTime dateTime,
            ITokenService tokenService)
        {
            _userDbContext = userDbContext;
            _authSettings = options.Value;
            // _dateTime = dateTime;
            _tokenService = tokenService;
        }

        public async Task<UserTokenModel> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            User user = await _userDbContext.User
                .SingleOrDefaultAsync(u => u.UserName == request.UserName);

            VerifyUserExists(request, user);

            if (!Verify(request.Password, user.Password))
            {

                await _userDbContext.SaveChangesAsync(cancellationToken);

                throw new AuthenticationException("Invalid username or password");
            }

            return new UserTokenModel
            {
                AccessToken = _tokenService.GenerateToken(user)
            };
        }

        private void VerifyUserExists(LoginUserCommand request, User entity)
        {
            if (entity == null)
            {
                throw new Exception("User Not Found");
            }
        }
    }
}