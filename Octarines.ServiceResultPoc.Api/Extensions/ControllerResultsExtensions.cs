using Microsoft.AspNetCore.Mvc;
using Octarines.ServiceResultPoc.Models.ServiceResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Octarines.ServiceResultPoc.Api.Extensions
{
    public static class ControllerResultsExtensions
    {
        public static IActionResult FromResult<T>(this ControllerBase controller, Result<T> result)
        {
            switch (result.ResultType)
            {
                case ResultType.Success:
                    return EqualityComparer<T>.Default.Equals(result.Value, default(T)) ? controller.NoContent() : controller.Ok(result.Value);
                case ResultType.NotFound:
                    return controller.NotFound(result.Errors);
                case ResultType.Invalid:
                    return controller.BadRequest(result.Errors);
                case ResultType.Unexpected:
                    return controller.BadRequest(result.Errors);
                case ResultType.Unauthorized:
                    return controller.Unauthorized();
                default:
                    throw new Exception("An unhandled result has occurred as a result of a service call.");
            }
        }
    }
}
