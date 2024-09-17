using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options) : base(options)
    {
    }
    public DbSet<User> users { get; set; }
    public DbSet<Key> keys { get; set; }
    public DbSet<Report> reports { get; set; }
    public DbSet<Token> tokens { get; set; }
    public DbSet<Room> rooms { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new KeyEntityConfiguration());
        modelBuilder.ApplyConfiguration(new UserEntityConfiguration());
        modelBuilder.ApplyConfiguration(new RoomEntityConfiguration());
        modelBuilder.ApplyConfiguration(new TokenEntityConfiguration());
        modelBuilder.ApplyConfiguration(new ReportEntityConfiguration());
        base.OnModelCreating(modelBuilder);
    }
}