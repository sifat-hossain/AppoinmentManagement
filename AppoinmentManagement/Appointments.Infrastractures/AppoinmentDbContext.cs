using Appointments.Application;
using Appointments.Domain.Entities;

namespace Appointments.Infrastractures;

public class AppointmentDbContext(DbContextOptions options) : DbContext(options), IAppointmentDbContext
{
    public DbSet<Doctor> Doctor { get; set; }
    public DbSet<Appointment> Appointment { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppointmentDbContext).Assembly);

    }
}
