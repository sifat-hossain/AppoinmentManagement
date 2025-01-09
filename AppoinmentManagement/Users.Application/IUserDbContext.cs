using Users.Domain.Entities;

namespace Users.Application;

/// <summary>
/// The interface to abstract the User database
/// </summary>
public interface IUserDbContext
{
    DbSet<User> User { get; set; }

    /// <summary>
    /// Saves the changes
    /// </summary>
    /// <returns>The number of state entries written to the database</returns>
    int SaveChanges();

    /// <summary>
    /// Saves the changes async
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns>The number of state entries written to the database</returns>
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}