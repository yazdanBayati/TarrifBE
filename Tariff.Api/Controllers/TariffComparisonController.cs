using Microsoft.AspNetCore.Mvc;
using Tariff.ApplicationService.TariffComparison;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Tariff.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TariffComparisonController : ControllerBase
    {

        private readonly ITariffComparisonService _tariffComparisonService;

        public TariffComparisonController(ITariffComparisonService tariffComparisonService)
        {
            _tariffComparisonService = tariffComparisonService;
        }

        /// <summary>
        /// Compares available tariffs based on the provided consumption.
        /// </summary>
        /// <param name="consumption">The annual electricity consumption in kWh.</param>
        /// <returns>A response containing the list of tariffs and their costs.</returns>
        [HttpGet("compare")]
        public async Task<IActionResult> Get( int consumption)
        {
            // Call the service to get the tariff comparison data
            var response = await _tariffComparisonService.CompareTariffs(consumption);
           
            return Ok(response);
        }
     
    }
}
