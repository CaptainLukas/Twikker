using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Forsthuber.Data.Data;
using Forsthuber.Data.Entities;
using Forsthuber.Data.Repositories;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Forsthuber.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // build the host for the web application
            var host = BuildWebHost(args);

            // Initializing initial seeding methods for the database
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                try
                {
                    DataBaseContext context = (DataBaseContext)services.GetService(typeof(DataBaseContext));
                    UserManager<ApplicationUser> usermanager = (UserManager<ApplicationUser>)services.GetService(typeof(UserManager<ApplicationUser>));
                    Logger<Repository> logger = (Logger<Repository>)services.GetService(typeof(Logger<Repository>));
                    Repository repository = new Repository(usermanager, context, logger);
                    DbInitializer initializer = new DbInitializer(context, repository);
                    initializer.Seed(context);
                }
                catch (Exception)
                {
                }
            }
            host.Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
    }
}
