using System.Collections.Generic;
using Domain.Common;

namespace Domain.Teams
{
    public interface ITeamsRepository : IRepository<Team>
    {
        IList<Team> GetAllIncludingPlayers();
    }
}
