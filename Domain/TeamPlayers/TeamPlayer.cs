using System;
using Domain.Common;
using Domain.Players;
using Domain.Teams;

namespace Domain.TeamPlayers
{
    public class TeamPlayer : Entity
    {
        public virtual Team Team { get; private set; }
        public Guid TeamId { get; private set; }
        public virtual Player Player { get; private set; }
        public Guid PlayerId { get; private set; }

        public TeamPlayer(Guid teamId, Guid playerId)
        {
            TeamId = teamId;
            PlayerId = playerId;
        }
    }
}
