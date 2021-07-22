using System;
using BooksApp.Areas.Identity.Data;
using BooksApp.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(BooksApp.Areas.Identity.IdentityHostingStartup))]
namespace BooksApp.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<BooksDbContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("BooksDbContextConnection")));

                services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = false)
                    .AddEntityFrameworkStores<BooksDbContext>();
            });
        }
    }
}