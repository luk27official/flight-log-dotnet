namespace FlightLogNet.Controllers
{
    using System.Collections.Generic;
    using Facades;
    using FlightLogNet.Models;
    using Microsoft.AspNetCore.Cors;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;


    [ApiController]
    [EnableCors]
    [Route("[controller]")]
    public class AirplaneController(ILogger<AirplaneController> logger, AirplaneFacade airplaneFacade)
        : ControllerBase
    {
        // DONE 3.1: Vystavte REST HTTPGet metodu vracející seznam klubových letadel
        // Letadla získáte voláním airplaneFacade
        // dotazované URL je /airplane
        // Odpověď by měla být kolekce AirplaneModel

        [HttpGet]
        public IEnumerable<AirplaneModel> GetPlanesInAir()
        {
            logger.LogDebug("Get airplanes.");
            return airplaneFacade.GetClubAirplanes();
        }
    }
}
