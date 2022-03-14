using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using WeatherAPI.Context;

namespace WeatherAPI.Models
{
    public static class PrepDB
    {
        public static void PrepPopulation(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                SeedData((serviceScope.ServiceProvider.GetService<WeatherContext>()));
            }
        }

        public static void SeedData(WeatherContext context)
        {
            Console.WriteLine("Applying Migrations...");
            context.Database.Migrate();

            if (!context.WeatherSet.Any())
            {
                Console.WriteLine("Adding data - seeding...");
                context.WeatherSet.AddRange(
                    new Weather()
                    {
                        HappenDate = new DateTime(2020,12,10),
                        TemperatureC = 10,
                        Summary = "Cool"
                    },
                    new Weather()
                    {
                        HappenDate = new DateTime(2020, 12, 11),
                        TemperatureC = 11,
                        Summary = "Mild"
                    },
                    new Weather()
                    {
                        HappenDate = new DateTime(2020, 12, 12),
                        TemperatureC = 12,
                        Summary = "Mild"
                    },
                    new Weather()
                    {
                        HappenDate = new DateTime(2020, 12, 13),
                        TemperatureC = 13,
                        Summary = "Balmy"
                    },
                    new Weather()
                    {
                        HappenDate = new DateTime(2020, 12, 14),
                        TemperatureC = 14,
                        Summary = "Hot"
                    });
                context.SaveChanges();
            }
            else
            {
                Console.WriteLine("Already have data - not seeding");
            }
        }
    }
}
