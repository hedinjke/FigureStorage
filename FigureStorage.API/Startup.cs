using AutoMapper;
using FigureStorage.API.Binders;
using FigureStorage.API.Extensions;
using FigureStorage.API.Mapper;
using FigureStorage.Models;
using FigureStorage.Repo;
using FigureStorage.Repo.Interfaces;
using FigureStorage.Repo.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace FigureStorage.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAutoMapper(cfg => {cfg.AddProfile<FigureProfile>(); });

            services.AddControllers()
                    .AddNewtonsoftJson(options =>
                     {
                         options.SerializerSettings.Converters
                                .Add(new InheritorsToBaseTypeJsonConverter<Figure>());
                     });

            services.AddScoped<IRepositoryContextFactory, RepositoryContextFactory>(
                provider => new RepositoryContextFactory(builder =>
                    builder.UseSqlite(Configuration.GetConnectionString("Default"),
                        options => options.MigrationsAssembly(typeof(Startup).Assembly.FullName))));

            services.AddScoped<IFigureRepository, FigureRepository>(provider =>
                new FigureRepository(provider.GetService<IRepositoryContextFactory>()));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                // endpoints.MapControllers();
                endpoints.MapControllerRoute("FigureApi", "api/v1/{controller}/{action?}");
            });
        }
    }
}