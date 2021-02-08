using Domain.Users;

namespace Domain.Common
{
    public interface ITokenService
    {
        string GenerateToken(User user);
    }
}