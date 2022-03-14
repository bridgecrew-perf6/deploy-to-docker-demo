using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WeatherAPI.Context;
using WeatherAPI.Models;

namespace WeatherAPI
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
            //sql server
            /*var server = Configuration["DBServer"] ?? "ms-sql-server";
            var port = Configuration["DBPort"] ?? "1433";
            var user = Configuration["DBUser"] ?? "SA";
            var password = Configuration["DBPassword"] ?? "G73gle73!";
            var database = Configuration["Database"] ?? "WeatherDB";

            services.AddDbContext<WeatherContext>(opt =>
            {
                opt.UseSqlServer(
                    $"Server={server},{port};Initial Catalog={database};User ID={user};Password={password}");
            });*/


            //postgresql
            /*services.AddEntityFrameworkNpgsql()
                .AddDbContext<WeatherContext>(options =>
                {
                    var connectionString = Configuration.GetConnectionString("DefaultConnection");
                    options.UseNpgsql(connectionString);
                });*/

            services.AddDbContext<WeatherContext>(options =>
            {
                options.UseMySql(Configuration.GetConnectionString("DefaultConnection"));
            });

            services.AddControllers();

            //services.AddDbContext<WeatherContext>(opt =>
            //{
            //    opt.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
            //});
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env,WeatherContext myContext)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            PrepDB.PrepPopulation(app);

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
