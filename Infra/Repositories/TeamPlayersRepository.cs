using System;
using Domain.TeamPlayers;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositories
{
    public class TeamPlayersRepository : Repository<TeamPlayer>, ITeamPlayersRepository
    {
        public TeamPlayersRepository(BrasileiraoContext DBContext) : base(DBContext)
        {
        }

        public void Remove(Guid id)
        {
            var teamPlayer = new TeamPlayer(id);
            brasileiraoContext.Entry(teamPlayer).State = EntityState.Deleted;
            brasileiraoContext.SaveChanges();
        }
    }
}
