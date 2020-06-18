using Kolokwium2.DTOs.Request;
using Kolokwium2.Exceptions;
using Kolokwium2.Services;
using Microsoft.AspNetCore.Mvc;

namespace Kolokwium2.Controllers
{
    [ApiController]
    [Route("api/teams")]
    public class TeamController : ControllerBase
    {
        private readonly ITournamentDataBaseService _service;

        public TeamController(ITournamentDataBaseService service)
        {
            _service = service;
        }

        [HttpPost("{id:int}/players")]
        public IActionResult AddPlayerToTeam(int id, PlayerRequest request)
        {
            try
            {
                _service.AddPlayerToTeam(id, request);
                return NoContent();
            }
            catch (PlayerNotExistsException e)
            {
                return NotFound(e.Message);
            }
            catch (WrongAgeException e)
            {
                return BadRequest(e.Message);
            }
            catch (PlayerAlreadyExistException e)
            {
                return BadRequest(e.Message);
            }
        }
        
    }
}