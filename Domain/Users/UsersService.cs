using System;
using Domain.Common;

namespace Domain.Users
{
    // Esta classe está IMPLEMENTANDO a interface IUsersService
    public class UsersService : IUsersService
    {
        private readonly IUsersRepository _usersRepository;
        private readonly ICrypt _crypt;

        public UsersService(IUsersRepository usersRepository, ICrypt crypt)
        {
            _usersRepository = usersRepository;
            _crypt = crypt;
        }

        public CreatedUserDTO Create(
            string name,
            UserProfile profile,
            string email,
            string password
        )
        {
            var cryptPassword = _crypt.CreateMD5(password);
            
            var user = new User(name, cryptPassword, email, profile);
            var userValidation = user.Validate();

            if (userValidation.isValid)
            {
                _usersRepository.Add(user);
                return new CreatedUserDTO(user.Id);
            }

            return new CreatedUserDTO(userValidation.errors);
        }
        
        public User GetById(Guid id)
        {
            return _usersRepository.Get(id);
        }
    }
}
