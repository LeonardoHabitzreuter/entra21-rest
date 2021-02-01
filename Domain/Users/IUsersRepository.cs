using System;
using Domain.Common;

namespace Domain.Users
{
    public interface IUsersRepository : IRepository<User>
    {
        User GetById(Guid id);
    }
}
