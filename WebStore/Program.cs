using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using WebStore.DAL;
using WebStore.Domain.Entities.Identity;

namespace WebStore
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = BuildWebHost(args);

            using (var scope = host.Services.CreateScope()) // нужно для получения DbContext
            {
                var services = scope.ServiceProvider;
                try
                {
                    WebStoreContext context = services.GetRequiredService<WebStoreContext>();
                    DAL.TestDBInitializer.DBInitializer.Initialize(context);
                    RoleStore<IdentityRole> roleStore = new RoleStore<IdentityRole>(context);
                    RoleManager<IdentityRole> roleManager = new RoleManager<IdentityRole>(roleStore, 
                        new IRoleValidator<IdentityRole>[] { },
                        new UpperInvariantLookupNormalizer(),
                        new IdentityErrorDescriber(), null);

                    if (!roleManager.RoleExistsAsync("User").Result)
                    {
                        IdentityRole role = new IdentityRole("User");
                        IdentityResult result = roleManager.CreateAsync(role).Result;
                    }

                    if (!roleManager.RoleExistsAsync("Administrator").Result)
                    {
                        IdentityRole role = new IdentityRole("Administrator");
                        IdentityResult result = roleManager.CreateAsync(role).Result;
                    }

                    UserStore<User> userStore = new UserStore<User>(context);
                    UserManager<User> userManager = new UserManager<User>(userStore, 
                        new OptionsManager<IdentityOptions>(
                            new OptionsFactory<IdentityOptions>(
                                new IConfigureOptions<IdentityOptions>[] { },
                            new IPostConfigureOptions<IdentityOptions>[] { })),
                        new PasswordHasher<User>(), 
                        new IUserValidator<User>[] { }, 
                        new IPasswordValidator<User>[] { },
                        new UpperInvariantLookupNormalizer(), 
                        new IdentityErrorDescriber(), 
                        null, 
                        null);

                    if (userStore.FindByEmailAsync("admin@mail.com", CancellationToken.None).Result == null)
                    {
                        User user = new User() { UserName = "Admin", Email = "admin@mail.com" };
                        IdentityResult result = userManager.CreateAsync(user, "admin").Result;
                        if (result == IdentityResult.Success)
                        {
                            var roleResult = userManager.AddToRoleAsync(user, "Administrator").Result;
                        }
                    }

                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "Oops. Something went wrong at DB initializing...");
                }
            }

            host.Run();
        }

        //public static IHostBuilder CreateHostBuilder(string[] args) =>
        //    Host.CreateDefaultBuilder(args)
        //        .ConfigureWebHostDefaults(webBuilder =>
        //        {
        //            webBuilder.UseStartup<Startup>();
        //        });
        private static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
    }
}
