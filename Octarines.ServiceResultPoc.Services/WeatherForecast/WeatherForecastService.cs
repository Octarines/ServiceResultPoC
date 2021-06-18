using Octarines.ServiceResultPoc.Models.ServiceResults;
using Octarines.ServiceResultPoc.Models.WeatherForecast;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Octarines.ServiceResultPoc.Services.WeatherForecast
{
    public class WeatherForecastService : IWeatherForecastService
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        public async Task<Result<WeatherForecastViewModel>> GetWeatherForecast()
        {
            Random rng = new Random();

            WeatherForecastViewModel forecast = Enumerable.Range(1, 5).Select(index => new WeatherForecastViewModel
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            }).First();

            if (false)
            {
                return new InvalidResult<WeatherForecastViewModel>();
            }

            return new SuccessResult<WeatherForecastViewModel>(forecast);
        }
    }
}
