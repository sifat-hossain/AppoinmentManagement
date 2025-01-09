
namespace Appoinments.Application;

public interface IAppoinmentDbContext
{
    DbSet<Appointment> Appointment { get; set; }
    DbSet<Doctor> Doctor { get; set; }


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
