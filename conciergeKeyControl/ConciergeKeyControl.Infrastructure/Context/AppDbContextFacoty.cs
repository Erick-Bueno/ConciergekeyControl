using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
public class AppDbContextFacoty : IDesignTimeDbContextFactory<AppDbContext>
{
    public AppDbContext CreateDbContext(string[] args){
        //localizar o appsettings.Development.json
        var basePath = Path.Combine(Directory.GetCurrentDirectory(), "..", "ConciergeKeyControl.Api");
        var configuration = new ConfigurationBuilder()
        .SetBasePath(basePath)
        .AddJsonFile("appsettings.Development.json")
        .Build();
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        var options = new DbContextOptionsBuilder<AppDbContext>();
        //as migracoes devem ser salvas no msm assembly(.dll ou .exe) que possui a classe AppDbContext
        options.UseSqlServer(connectionString, m => m.MigrationsAssembly(typeof(AppDbContext).Assembly.FullName));
        return new AppDbContext(options.Options);
    }
}