
using Domain.Players;

namespace Infra.Repositories
{
    public class PlayersRepository : Repository<Player>, IPlayersRepository
    {
        public PlayersRepository(BrasileiraoContext DBContext) : base(DBContext)
        {
        }
    }
}
