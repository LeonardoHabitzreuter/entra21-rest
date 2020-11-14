using Microsoft.AspNetCore.Mvc;
using Domain.Players;
using Microsoft.Extensions.Primitives;
using Domain.Users;
using System;
using Microsoft.AspNetCore.Authentication;

namespace WebAPI.Controllers.Players
{
    [ApiController]
    [Route("[controller]")]
    public class PlayersController : ControllerBase
    {
        private readonly PlayersService _playersService;
        private readonly UsersService _usersService;
        
        public PlayersController()
        {
            _usersService = new UsersService();
            _playersService = new PlayersService();
        }

        [HttpPost]
        public IActionResult Create(CreatePlayerRequest request)
        {
            StringValues userId;
            if(!Request.Headers.TryGetValue("UserId", out userId))
            {
                return Unauthorized();
            }

            var user = _usersService.GetById(Guid.Parse(userId));

            if (user == null)
            {
                return Unauthorized();
            }

            if (user.Profile == Profile.Supporter)
            {
                return Unauthorized();
                // return Forbid("Test");
            }

            var response = _playersService.Create(request.Name);

            if (!response.IsValid)
            {
                return BadRequest(response.Errors);
            }
            
            return Ok(response.Id);
        }

        [HttpPut("{id}")]
        public IActionResult Update(Guid id, CreatePlayerRequest request)
        {
            StringValues userId;
            if(!Request.Headers.TryGetValue("UserId", out userId))
            {
                return Unauthorized();
            }

            var user = _usersService.GetById(Guid.Parse(userId));

            if (user == null)
            {
                return Unauthorized();
            }

            if (user.Profile != Profile.CBF)
            {
                return Unauthorized();
            }

            var response = _playersService.Update(id, request.Name);

            if (!response.IsValid)
            {
                return BadRequest(response.Errors);
            }
            
            return Ok(response.Id);
        }

        [HttpDelete("{id}")]
        public IActionResult Remove(Guid id)
        {
            StringValues userId;
            if(!Request.Headers.TryGetValue("UserId", out userId))
            {
                return Unauthorized();
            }

            var user = _usersService.GetById(Guid.Parse(userId));

            if (user == null)
            {
                return Unauthorized();
            }

            if (user.Profile != Profile.CBF)
            {
                return Unauthorized();
            }

            var playerRemoved = _playersService.Remove(id);

            if (playerRemoved == null)
            {
                return NotFound();
            }
            
            return NoContent();
        }
    }
}
