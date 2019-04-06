using System;
using EventManager.Data;
using EventManager.Data.Models;
using EventManager.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(EventManager.Areas.Identity.IdentityHostingStartup))]
namespace EventManager.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<EventManagerDbContext>(options =>
                    options.UseSqlServer(ConfigurationData.connectionString, c => c.MigrationsAssembly("EventManager")));

                services.AddDefaultIdentity<User>()
                    .AddEntityFrameworkStores<EventManagerDbContext>();
            });
        }
    }
}