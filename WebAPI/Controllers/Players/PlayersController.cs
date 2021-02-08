using Microsoft.AspNetCore.Mvc;
using Domain.Players;
using Microsoft.Extensions.Primitives;
using Domain.Users;
using System;

namespace WebAPI.Controllers.Players
{
    [ApiController]
    [Route("[controller]")]
    public class PlayersController : ControllerBase
    {
        private readonly PlayersService _playersService;
        private readonly IUsersService _usersService;
        
        public PlayersController(IUsersService usersService)
        {
            _usersService = usersService;
            _playersService = new PlayersService();
        }

        [HttpPost]
        public IActionResult Create(CreatePlayerRequest request)
        {
           var response = _playersService.Create(request.TeamId, request.Name);

            if (!response.IsValid)
            {
                return BadRequest(response.Errors);
            }
            
            return Ok(response.Id);
        }

        [HttpDelete("{id}")]
        public IActionResult Remove(Guid id)
        {
            var playerRemoved = _playersService.Remove(id);

            if (playerRemoved == null)
            {
                return NotFound();
            }
            
            return NoContent();
        }
    }
}
