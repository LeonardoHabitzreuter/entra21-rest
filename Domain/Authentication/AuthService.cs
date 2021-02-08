using Domain.Common;
using Domain.Users;

namespace Domain.Authentication
{
    public class AuthService : IAuthService
    {
        private readonly IUsersRepository _usersRepository;
        private readonly ITokenService _tokenService;

        public AuthService(IUsersRepository usersRepository, ITokenService tokenService)
        {
            _usersRepository = usersRepository;
            _tokenService = tokenService;
        }

        public AuthResponse Login(string email, string password)
        {
            var user = _usersRepository.Get(x => x.Email == email);
            if (user == null)
            {
                return new AuthResponse();
            }

            var crypt = new Crypt();
            var cryptPassword = crypt.CreateMD5(password);

            if (user.Password != cryptPassword)
            {
                return new AuthResponse();
            }

            var token = _tokenService.GenerateToken(user);
            return new AuthResponse(token);
        }
    }
}
