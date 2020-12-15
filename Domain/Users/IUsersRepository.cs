using System;
using System.Linq;
using Domain.Infra;

namespace Domain.Users
{
    public interface IUsersRepository : IRepository<User>
    {
        User GetById(Guid id);
    }
}
