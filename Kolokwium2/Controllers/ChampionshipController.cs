using Kolokwium2.Services;
using Microsoft.AspNetCore.Mvc;

namespace Kolokwium2.Controllers
{
    
    [ApiController]
    [Route("api/championships")]
    public class ChampionshipController : ControllerBase
    {

        private readonly ITournamentDataBaseService _service;

        public ChampionshipController(ITournamentDataBaseService service)
        {
            _service = service;
        }

        [HttpGet("{id:int}/teams")]
        public IActionResult getTeams(int id)
        {
            var result = _service.getTeams(id);
            return Ok(result);
        }
    }
}