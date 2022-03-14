using System;
using System.ComponentModel.DataAnnotations;

namespace WeatherAPI.Models
{
    public class Weather
    {
        [Key]
        public int Id { get; set; }

        public DateTime HappenDate { get; set; }

        public int TemperatureC { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        public string Summary { get; set; }
    }
}
