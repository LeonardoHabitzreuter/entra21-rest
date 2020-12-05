namespace Domain.Teams
{
    public class TeamsService
    {
        public CreatedTeamDTO Create(string name)
        {
            var Team = new Team(name);
            var TeamValidation = Team.Validate();

            if (TeamValidation.isValid)
            {
                TeamsRepository.Add(Team);
                return new CreatedTeamDTO(Team.Id);
            }

            return new CreatedTeamDTO(TeamValidation.errors);
        }
    }
}
