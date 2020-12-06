using FigureStorage.Repo.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace FigureStorage.API.Extensions
{
    public static class HostExtensions
    {
        public static IHost ApplyMigrations(this IHost host)
        {
            var scope = host.Services.CreateScope();
            var factory = scope.ServiceProvider.GetService<IRepositoryContextFactory>();
            var context = factory.CreateDbContext();
            context.Database.Migrate();
            
            return host;
        }
    }
}