namespace Users.Infrastractures.Configuration;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable(nameof(User), b => b.IsTemporal());

        builder.HasKey(b => b.Id);

        builder.Property(b => b.Id)
            .UseIdentityColumn();

        builder.Property(b => b.UserName)
            .IsRequired()
            .HasMaxLength(Constants.FieldSize.Name);

        builder.HasIndex(b => b.UserName)
            .IsUnique();

        builder.Property(b => b.Password)
            .IsRequired()
            .HasMaxLength(Constants.FieldSize.Password);

        builder.HasData(
            new User
            {
                Id = 0,
                UserName = "demo",
                Password = "$2a$11$aOVqtiiybxRP8jVf0Mye7./nR7QUW74fnuTrUjyTXpZ5fYYjKNrP6"
            }
            );

    }
}