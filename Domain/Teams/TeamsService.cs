﻿using System.Collections.Generic;

namespace Domain.Teams
{
    public class TeamsService
    {
        private readonly TeamsRepository _teamsRepository = new TeamsRepository();

        public CreatedTeamDTO Create(string name, IList<string> playersNames)
        {
            var team = new Team(name, playersNames);
            var TeamValidation = team.Validate();

            if (TeamValidation.isValid)
            {
                _teamsRepository.Add(team);
                return new CreatedTeamDTO(team.Id);
            }

            return new CreatedTeamDTO(TeamValidation.errors);
        }
    }
}
