using System;
using System.Collections.Generic;
using Domain.People;
using Domain.TeamPlayers;

namespace Domain.Players
{
    public class Player : Person
    {
        public int Goals { get; private set; }
        // A propriedade virtual indica ao EF que é uma propriedade de navegação
        public virtual IList<TeamPlayer> Teams { get; set; } = new List<TeamPlayer>();

        public Player(string name) : base(name)
        {
        }

        public void AddTeam(Guid teamId)
        {
            Teams.Add(new TeamPlayer(teamId, Id));
        }

        public (IList<string> errors, bool isValid) Validate()
        {
            var errors = new List<string>();
            if (!ValidateName())
            {
                errors.Add("Nome inválido.");
            }
            return (errors, errors.Count == 0);
        }
    }
}
