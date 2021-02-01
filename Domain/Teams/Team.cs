using System.Collections.Generic;
using System.Linq;
using Domain.Common;
using Domain.Players;

namespace Domain.Teams
{
    public class Team : Entity
    {
        public int Goals { get; private set; }
        public string Name { get; set; }
        public virtual IList<Player> Players { get; set; }

        public Team(string name, IList<string> players)
        {
            Name = name;
            if (players != null)
            {
                Players = players
                    .Select(playerName => new Player(Id, playerName))
                    .ToList();
            }
        }

        protected Team() {}

        protected bool ValidateName()
        {
            if (string.IsNullOrEmpty(Name))
            {
                return false;
            }

            var words = Name.Split(' ');

            foreach (var word in words)
            {
                if (word.Trim().Length < 2)
                {
                    return false;
                }
                if (word.Any(x => !char.IsLetter(x)))
                {
                    return false;
                }
            }

            return true;
        }

        public (IList<string> errors, bool isValid) Validate()
        {
            var errors = new List<string>();
            if (!ValidateName())
            {
                errors.Add("Nome inválido.");
            }
            if (Players != null)
            {
                Players.Any(player => !player.Validate().isValid);
                errors.Add("Há jogadores inválidos");
            }
            return (errors, errors.Count == 0);
        }
    }
}
