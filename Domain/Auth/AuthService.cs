using System;
using System.Linq;
using System.Security.Cryptography;
using Domain.Users;

namespace Domain.Auth
{
    public class AuthService
    {
        public LoginDTO Login(string name, string password)
        {
            var user = UsersRepository.Users.FirstOrDefault(x => x.Name == name);
            
            if (user == null)
            {
                return new LoginDTO("Login inválido.");
            }

            if (!user.PasswordEquals(password))
            {
                return new LoginDTO("Login inválido.");
            }
    
            return new LoginDTO(user.Id);
        }
        
        public User GetById(Guid id)
        {
            return UsersRepository.Users.FirstOrDefault(x => x.Id == id);
        }
    }
}
