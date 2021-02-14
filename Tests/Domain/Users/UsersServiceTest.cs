using Domain.Common;
using Domain.Users;
using Moq;
using Xunit;

namespace Tests.Domain.Users
{
    public class UsersServiceTest
    {
        private Mock<IUsersRepository> _usersRepository;
        private Mock<ICrypt> _crypt;
        private UsersService _usersService;

        public UsersServiceTest()
        {
            _usersRepository = new Mock<IUsersRepository>();
            _crypt = new Mock<ICrypt>();
            _usersService = new UsersService(_usersRepository.Object, _crypt.Object);
        }

        [Fact]
        public void Should_not_create_user_when_has_validation_errors()
        {
            var resp = _usersService.Create("João", UserProfile.CBF, "", "");

            Assert.False(resp.IsValid);

            // verificando que o método "Add" nunca foi chamado com qualquer parâmetro do tipo "User"
            _usersRepository.Verify(
                x => x.Add(It.IsAny<User>()),
                Times.Never()
            );
        }

        [Fact]
        public void Should_create_user_when_is_valid()
        {
            const string password = "123456";
            const string crypetdPass = "crypetdPass";
            _crypt.Setup(x => x.CreateMD5(password)).Returns(crypetdPass);

            var resp = _usersService.Create(
                "João Silva",
                UserProfile.CBF,
                "joao.silva@gmail.com",
                password
            );

            Assert.True(resp.IsValid);
            _usersRepository.Verify(x => x.Add(It.Is<User>(x =>
                x.Name == "João Silva" &&
                x.Profile == UserProfile.CBF &&
                x.Email == "joao.silva@gmail.com" &&
                x.Password == crypetdPass
            )), Times.Once());
        }
    }
}
