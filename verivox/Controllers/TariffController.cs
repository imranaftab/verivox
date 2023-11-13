using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using verivox.Converters;
using verivox.Interfaces;
using verivox.Models;

namespace verivox.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TariffController : Controller
    {
        private readonly ITariffCalculationService _tariffCalculationService;

        public TariffController(ITariffCalculationService tariffCalculatorService)
        {
            this._tariffCalculationService = tariffCalculatorService;
        }

        /// <summary>
        /// Get electricity tariff calculations based on the annual consumptions.
        /// </summary>
        /// <param name="consumption">Consumption (kWh/year)</param>
        /// <returns>Returns the list of tariff result calculations containing tariff name and annual cost (€/year) depending on the consumptions input parameter. </returns>
        [HttpGet("Calculations/{consumption}")]
        public ActionResult Calculations(int consumption)
        {
            try
            {
                if(consumption <= 0) 
                {
                    return Ok(new {success = false, message = "Consumption must be greater than 0"});
                }

                var calculationResults = _tariffCalculationService.GetCalculationResults(consumption);
                
                return Ok(new { success = true, data = calculationResults } );

            }
            catch (Exception)
            {
                return Ok(new {success = false, message = "Something went wrong"});
            }

        }
    }
}
