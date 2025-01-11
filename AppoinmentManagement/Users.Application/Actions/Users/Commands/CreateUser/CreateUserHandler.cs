using Users.Domain.Entities;
using static BCrypt.Net.BCrypt;

namespace Users.Application.Actions.Users.Commands.CreateUser
{
    /// <summary>
    /// Represents logic for CreateUserCommand
    /// </summary>
    public class CreateUserHandler(IUserDbContext userDbContext) :
        IRequestHandler<CreateUserCommand, UserModel>
    {
        private readonly IUserDbContext _userDbContext = userDbContext;

        public async Task<UserModel> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            try
            {


                User? existingUser = await _userDbContext.User
                    .FirstOrDefaultAsync(u => u.UserName == request.UserName, cancellationToken: cancellationToken);

                //if (existingUser != null)
                //{
                //    throw new ConflictException(nameof(User), request.UserName);
                //}


                var user = new User
                {
                    UserName = request.UserName,
                    Password = HashPassword(request.Password),
                };

                _userDbContext.User.Add(user);

                await _userDbContext.SaveChangesAsync(cancellationToken);
                return UserModel.Create(user);
            }
            catch (Exception e)
            {
                var x = e.Message + e.InnerException?.Message;
                throw;
            }
        }
    }
}