using System;
using System.Collections.Generic;
using System.Linq;
using Domain.People;
using Domain.Players;

namespace Domain.Teams
{
    public class Team
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
        public int Goals { get; private set; }
        public string Name { get; set; }
        public virtual IList<Player> Players { get; set; }

        public Team(string name)
        {
            Name = name;
        }

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
