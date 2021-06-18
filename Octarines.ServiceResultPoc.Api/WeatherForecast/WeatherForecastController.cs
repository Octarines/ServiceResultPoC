using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Octarines.ServiceResultPoc.Api.Extensions;
using Octarines.ServiceResultPoc.Models.ServiceResults;
using Octarines.ServiceResultPoc.Models.WeatherForecast;
using Octarines.ServiceResultPoc.Services.WeatherForecast;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Octarines.ServiceResultPoc.Api.WeatherForecast
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {

        private readonly IWeatherForecastService _weatherForecastService;
        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(IWeatherForecastService weatherForecastService, ILogger<WeatherForecastController> logger)
        {
            _weatherForecastService = weatherForecastService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetWeatherForecast()
        {

            Result<WeatherForecastViewModel> result = await _weatherForecastService.GetWeatherForecast();

            return this.FromResult(result);
        }
    }
}
