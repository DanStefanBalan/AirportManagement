using AirportManagement.Data;
using AirportManagement.Repo;
using AirportManagement.Service.Implementation;
using AirportManagement.Service.Repository;
using AirportManagement.API.Validations;
using AutoMapper;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace AirportManagement.API
{
    public class Startup
    {
        private IConfiguration _config;

        public Startup(IConfiguration config)
        {
            _config = config;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //Validation
            services.AddMvc()
                .AddFluentValidation(fv =>
                {
                    fv.RegisterValidatorsFromAssemblyContaining<AirportValidation>();
                    fv.RegisterValidatorsFromAssemblyContaining<AircraftValidation>();
                    fv.RegisterValidatorsFromAssemblyContaining<DestinationValidation>();
                    fv.RegisterValidatorsFromAssemblyContaining<FlightValidation>();
                    fv.RegisterValidatorsFromAssemblyContaining<GateValidation>();
                    fv.RegisterValidatorsFromAssemblyContaining<Terminal>();
                });


            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader());
            });
            //mapping
            var _mapperConfiguration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MapingEntities());
            });
            services.AddMvcCore().SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
            services.AddSingleton(_mapperConfiguration.CreateMapper());
            services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(_config.GetConnectionString("AirportManagementDBConnection")));
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            //services
            services.AddTransient<IAirportService, AirportService>();
            services.AddTransient<IAircraftService, AircraftService>();
            services.AddTransient<IDestinationService, DestinationService>();
            services.AddTransient<IFlightService, FlightService>();
            services.AddTransient<IGateService, GateService>();
            services.AddTransient<ITerminalService, TerminalService>();
            services.AddSingleton(_mapperConfiguration);
            services.AddCors();
            services.AddAuthorization();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseAuthorization();
            app.UseCors("CorsPolicy");
            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}
