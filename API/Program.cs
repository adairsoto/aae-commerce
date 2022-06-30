using Main.Models.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Support.Data;
using Support.Identity;

namespace API
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var loggerFactory = services.GetRequiredService<ILoggerFactory>();
                try 
                {
                    var context = services.GetRequiredService<LojaContext>();
                    await context.Database.MigrateAsync();
                    await LojaContextSeed.SeedAsync(context, loggerFactory);

                     var userManager = services.GetRequiredService<UserManager<AppUser>>();
                     var identityContext = services.GetRequiredService<AppIdentityDbContext>();
                     await identityContext.Database.MigrateAsync();
                     await AppIdentityDbContextSeed.SeedUsersAsync(userManager);
                }
                catch(Exception ex)
                {
                    var logger = loggerFactory.CreateLogger<Program>();
                    logger.LogError(ex, "An error occured during migration");
                }
            }
            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
