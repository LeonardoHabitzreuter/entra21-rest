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
        private readonly IPlayersService _playersService;
        private readonly IUsersService _usersService;
        
        public PlayersController(IUsersService usersService, IPlayersService playersService)
        {
            _usersService = usersService;
            _playersService = playersService;
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
    }
}
