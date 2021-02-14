using System.Collections.Generic;

namespace Domain.Teams
{
    public class TeamsService : ITeamsService
    {
        private readonly ITeamsRepository _teamsRepository;
        public TeamsService(ITeamsRepository teamsRepository)
        {
            _teamsRepository = teamsRepository;
        }

        public CreatedTeamDTO Create(string name)
        {
            var team = new Team(name);
            var TeamValidation = team.Validate();

            if (TeamValidation.isValid)
            {
                _teamsRepository.Add(team);
                return new CreatedTeamDTO(team.Id);
            }

            return new CreatedTeamDTO(TeamValidation.errors);
        }

        public IList<Team> GetAll()
        {
            return _teamsRepository.GetAllIncluding(x => x.Players);
        }
    }
}
