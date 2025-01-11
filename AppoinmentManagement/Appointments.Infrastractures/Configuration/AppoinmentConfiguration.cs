using Appointments.Domain.Entities;

namespace Appointments.Infrastractures.Configuration;

public class AppoinmentConfiguration : IEntityTypeConfiguration<Appointment>
{
    public void Configure(EntityTypeBuilder<Appointment> builder)
    {
        builder.ToTable(nameof(Appointment), b => b.IsTemporal());

        builder.HasKey(b => b.Id);

        builder.Property(b => b.Id)
            .UseIdentityColumn();

        builder.Property(b => b.AppointmentDateTime)
            .HasColumnType(Constants.Precision.DateTime);

        builder.Property(b => b.IsDeleted)
            .HasDefaultValue(false);

        builder.Property(b => b.PatientName)
            .HasMaxLength(Constants.FieldSize.Name);

        builder.Property(b => b.Phone)
            .IsRequired()
           .HasMaxLength(Constants.FieldSize.TelephoneNumber);

        builder.HasOne(d => d.Doctor)
            .WithMany(a => a.Appointments)
            .HasForeignKey(a => a.DoctorId);
    }
}
