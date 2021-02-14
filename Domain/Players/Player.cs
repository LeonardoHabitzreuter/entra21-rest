using System.Collections.Generic;
using Domain.People;
using Domain.TeamPlayers;

namespace Domain.Players
{
    public class Player : Person
    {
        public int Goals { get; private set; }
        // A propriedade virtual indica ao EF que é uma propriedade de navegação
        public virtual IList<TeamPlayer> Teams { get; set; }

        public Player(string name) : base(name)
        {
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
