using System.ComponentModel.DataAnnotations;

namespace ASPNET_WebAPI.Models
{
    public class WeatherForecast
    {
        public DateOnly Date { get; set; }   
        public required int TemperatureC { get; set; }
        
        public  int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
        public string? Summary { get; set; }
    }
}
