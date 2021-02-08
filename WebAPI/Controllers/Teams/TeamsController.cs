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
            var response = _teamsService.Create(request.Name, request.Players);

            if (!response.IsValid)
            {
                return BadRequest(response.Errors);
            }
            
            return Ok(response.Id);
        }

        [HttpGet]
        [Authorize(Roles = "CBF,Supporter")]
        public IActionResult Get(string name)
        {
            var teams = new List<Team>
            {
                new Team("Atletico Paranaense", new []{"Rony", "Madson", "Marcelo Cirino", "Léo Pereira", "Zé Evaldo"}),
                new Team("Atletico Mineiro", new []{"Hulk", "Guga", "Réver", "Victor", "Igor Rabelo"}),
                new Team("Parmera", new []{"Luix Adriano", "Breno", "Dudu", "Zé Rafael", "Marcos Rocha"}),
                new Team("Framengo", new []{"Coringa", "Neneca", "Gabigol", "Everton Miteiro", "Carrascaeta"})
            };

            if (string.IsNullOrWhiteSpace(name))
            {
                return Ok(teams);
            }

            var transformedName = name.ToLower().Trim();
            var filteredTeams = teams.Where(x => x.Name.ToLower().Contains(transformedName));
            return Ok(filteredTeams);
        }
    }
}
