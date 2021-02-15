using Domain.Users;

namespace Infra.Repositories
{
    public class UsersRepository : Repository<User>, IUsersRepository
    {
        public UsersRepository(BrasileiraoContext brasileiraoContext) : base(brasileiraoContext)
        {
        }
    }
}
