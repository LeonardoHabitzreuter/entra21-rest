using Microsoft.AspNetCore.Mvc;
using Domain.Teams;
using Domain.Users;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;

namespace WebAPI.Controllers.Teams
{
    [ApiController]
    [Route("[controller]")]
    public class TeamsController : ControllerBase
    {
        private readonly ITeamsService _teamsService;
        private readonly IUsersService _usersService;

        public TeamsController(IUsersService usersService, ITeamsService teamsService)
        {
            _usersService = usersService;
            _teamsService = teamsService;
        }

        [HttpPost]
        public IActionResult Create(CreateTeamRequest request)
        {
            var response = _teamsService.Create(request.Name);

            if (!response.IsValid)
            {
                return BadRequest(response.Errors);
            }
            
            return Ok(response.Id);
        }

        [HttpGet]
        // [Authorize(Roles = "CBF,Supporter")]
        public IActionResult Get(string name)
        {
            var teams = _teamsService.GetAll();

            // if (string.IsNullOrWhiteSpace(name))
            // {
            //     return Ok(teams);
            // }

            // var transformedName = name.ToLower().Trim();
            // var filteredTeams = teams.Where(x => x.Name.ToLower().Contains(transformedName));
            
            var resp = teams.Select(x => new {
                name = x.Name,
                players = x.Players.Select(y => y.Player.Name)
            });
            return Ok(resp);
        }
    }
}
