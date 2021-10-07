using Octarines.ServiceResultPoc.Models.Extensions;
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

            IEnumerable<WeatherForecastViewModel> forecasts = Enumerable.Range(1, 5).Select(index => new WeatherForecastViewModel
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            });

            IEnumerable<Result<bool>> results = await Task.WhenAll(forecasts.Select(async x => await ValidateForecast(x)));

            if(results.Any(x => x.HasErrors))
            {
                return results.AsErrorResult<WeatherForecastViewModel>();
            }

            return new SuccessResult<WeatherForecastViewModel>(forecasts.First());
        }

        public async Task<Result<bool>> ValidateForecast(WeatherForecastViewModel forecast)
        {
            //do some other nested business logic
            //return new SuccessResult<bool>(true);
            //return new InvalidResult<bool>("Test invalid error");
            //return new UnexpectedResult<bool>("Test unexpected error");
            //return new UnauthorizedResult<bool>();
            return new NotFoundResult<bool>("Test not found error");
        }
    }
}
