using System.Collections.Generic;
using System.Linq;
using Domain.Common;
using Domain.TeamPlayers;

namespace Domain.Teams
{
    public class Team : Entity
    {
        public int Goals { get; private set; }
        public string Name { get; set; }
        public virtual IList<TeamPlayer> Players { get; set; }

        public Team(string name)
        {
            Name = name;
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
            return (errors, errors.Count == 0);
        }
    }
}
