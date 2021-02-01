using Microsoft.AspNetCore.Mvc;
using Domain.Teams;
using Microsoft.Extensions.Primitives;
using Domain.Users;
using System;

namespace WebAPI.Controllers.Teams
{
    [ApiController]
    [Route("[controller]")]
    public class TeamsController : ControllerBase
    {
        private readonly TeamsService _teamsService;
        private readonly IUsersService _usersService;

        public TeamsController(IUsersService usersService, TeamsService teamsService)
        {
            _usersService = usersService;
            _teamsService = teamsService;
        }

        [HttpPost]
        public IActionResult Create(CreateTeamRequest request)
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
            }

            var response = _teamsService.Create(request.Name, request.Players);

            if (!response.IsValid)
            {
                return BadRequest(response.Errors);
            }
            
            return Ok(response.Id);
        }
    }
}
