namespace Users.Infrastractures;

public class UserDbContext(DbContextOptions options) : DbContext(options), IUserDbContext
{
    public DbSet<User> User { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(UserDbContext).Assembly);
    }
}