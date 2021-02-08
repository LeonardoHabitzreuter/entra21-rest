using System;

namespace Domain.Users
{
    public interface IUsersService
    {
        CreatedUserDTO Create(
            string name,
            UserProfile profile,
            string email,
            string password
        );

        User GetById(Guid id);
    }
}
