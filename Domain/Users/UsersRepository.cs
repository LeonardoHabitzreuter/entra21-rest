using System;
using System.Linq;
using Domain.Infra;

namespace Domain.Users
{
    class UsersRepository : Repository<User>
    {
        public User GetById(Guid id)
        {
            using (var db = new BrasileiraoContext())
            {
                return db.Users.FirstOrDefault(x => x.Id == id);
            }
        }
    }
}
