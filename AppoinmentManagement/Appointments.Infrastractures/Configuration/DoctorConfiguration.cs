using Appointments.Domain.Entities;

namespace Appointments.Infrastractures.Configuration;

public class DoctorConfiguration : IEntityTypeConfiguration<Doctor>
{
    public void Configure(EntityTypeBuilder<Doctor> builder)
    {
        builder.ToTable(nameof(Doctor), b => b.IsTemporal());

        builder.HasKey(b => b.Id);

        builder.Property(b => b.Id)
            .UseIdentityColumn();

        builder.Property(b => b.DoctorName)
            .HasMaxLength(Constants.FieldSize.Name);

        builder.Property(b => b.IsDeleted)
          .HasDefaultValue(false);

    }
}
