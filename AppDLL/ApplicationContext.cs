using AppDLL.Entity;
using Microsoft.EntityFrameworkCore;

namespace AppDLL;
public class ApplicationContext : DbContext
{
    public DbSet<AuthToken> AuthTokens { get; set; } = null;
    public DbSet<Role> Roles { get; set; } = null;
    public DbSet<Client> Clients { get; set; } = null;
    public DbSet<Human> Humans { get; set; } = null;
    public DbSet<Order> Orders { get; set; } = null;
    public DbSet<Status> Statuses { get; set; } = null;


    public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
    {
        Database.Migrate();
        Context.AddDb(this);
    }


    public static string ConnectionString = "Host=localhost;Port=5432;Database=web_db;Username=postgres;Password=12";
    public static DbContextOptions<ApplicationContext> GetDb()
    {
        var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();
        return optionsBuilder.UseLazyLoadingProxies().UseNpgsql(ConnectionString).Options;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
    }
}
