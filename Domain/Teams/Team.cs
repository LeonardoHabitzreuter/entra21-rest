using System;
using System.Collections.Generic;
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
    }
}
