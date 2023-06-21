using Microsoft.AspNetCore.Mvc;

namespace SecApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        

        [HttpGet(Name = "GetWeatherForecast")]
        public void Get()
        {
            
        }
    }
}