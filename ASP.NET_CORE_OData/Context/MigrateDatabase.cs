using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Microsoft.AspNetCore.Hosting
{
    public static class IWebHostExtensions
    {
        /// <summary>
        /// When Auth.service run,will create the database if it doesn't already exist. 
        /// </summary>
        /// <typeparam name="TContext"></typeparam>
        /// <param name="webHost"></param>
        /// <param name="seeder"></param>
        /// <returns></returns>
        public static IWebHost MigrateDbContext<TContext>(this IWebHost webHost, Action<TContext, IServiceProvider> seeder) where TContext : DbContext
        {
            using (var scope = webHost.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                var context = services.GetService<TContext>();

                try
                {
                    //var retry = Policy.Handle<SqlException>()
                    //     .WaitAndRetry(new TimeSpan[]
                    //     {
                    //         TimeSpan.FromSeconds(3),
                    //         TimeSpan.FromSeconds(5),
                    //         TimeSpan.FromSeconds(8),
                    //     });

                    //retry.Execute(() =>
                    //{
                    //if the sql server container is not created on run docker compose this
                    //migration can't fail for network related exception. The retry options for DbContext only 
                    //apply to transient exceptions.

                    if (context.Database.EnsureCreated())
                    {
                        context.Database.Migrate();
                        seeder(context, services);
                    }
                    //});

                }
                catch (Exception ex)
                {
                }
            }

            return webHost;
        }
    }
}
