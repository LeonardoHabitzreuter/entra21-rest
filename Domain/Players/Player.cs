using System;
using System.Collections.Generic;
using System.Linq;
using Domain.People;
using Domain.Teams;

namespace Domain.Players
{
    public class Player : Person
    {
        public int Goals { get; private set; }
        // A propriedade virtual indica ao EF que é uma propriedade de navegação
        public virtual Team Team { get; private set; }
        public Guid TeamId { get; private set; }

        public Player(Guid teamId, string name) : base(name)
        {
            TeamId = teamId;
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
