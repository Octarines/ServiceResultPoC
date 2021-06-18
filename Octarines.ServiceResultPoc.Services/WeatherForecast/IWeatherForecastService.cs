using Octarines.ServiceResultPoc.Models.ServiceResults;
using Octarines.ServiceResultPoc.Models.WeatherForecast;
using System.Threading.Tasks;

namespace Octarines.ServiceResultPoc.Services.WeatherForecast
{
    public interface IWeatherForecastService
    {
        public Task<Result<WeatherForecastViewModel>> GetWeatherForecast();
    }
}
