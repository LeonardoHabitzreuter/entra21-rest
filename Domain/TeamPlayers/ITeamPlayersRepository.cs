using System;
using Domain.Common;

namespace Domain.TeamPlayers
{
    public interface ITeamPlayersRepository : IRepository<TeamPlayer>
    {
        void Remove(Guid id);
    }
}
