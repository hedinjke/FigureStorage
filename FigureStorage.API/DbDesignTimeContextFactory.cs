using System;
using FigureStorage.Repo;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace FigureStorage.API
{
    public class DbDesignTimeContextFactory : IDesignTimeDbContextFactory<RepositoryContext>
    {
        public RepositoryContext CreateDbContext(string[] args)
        {
            var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            Console.WriteLine($"Env is {env}");

            var configuration = new ConfigurationBuilder()
                               .AddJsonFile($"appsettings.json")
                               .AddJsonFile($"appsettings.{env}.json", optional: true)
                               .Build();

            var connectionString = configuration.GetConnectionString("Default");
            
            return new RepositoryContextFactory(builder => builder.UseSqlite(connectionString, 
                optionsBuilder => optionsBuilder.MigrationsAssembly(typeof(Startup).Assembly.FullName))).CreateDbContext();
        }
    }
}