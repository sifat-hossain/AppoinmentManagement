using Appoinments.Application;

namespace Appoinments.Infrastractures;

public class AppoinmentDbContext(DbContextOptions options) : DbContext(options), IAppoinmentDbContext
{
    public DbSet<Doctor> Doctor { get; set; }
    public DbSet<Appointment> Appointment { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppoinmentDbContext).Assembly);

    }
}
