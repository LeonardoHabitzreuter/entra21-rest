
using System.Collections.Generic;
using System.Linq;
using Domain.Teams;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositories
{
    public class TeamsRepository : Repository<Team>, ITeamsRepository
    {
        public TeamsRepository(BrasileiraoContext brasileiraoContext) : base(brasileiraoContext) {}

        public IList<Team> GetAllIncludingPlayers()
        {
            return brasileiraoContext.Teams
                .Include(x => x.Players)
                .ThenInclude(x => x.Player)
                .ToList();
        }
    }
}
