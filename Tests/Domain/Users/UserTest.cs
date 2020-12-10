using System;
using Domain.Users;
using Xunit;

namespace Tests.Domain.Users
{
    public class UserTest
    {
        [Theory]
        [InlineData("joao")]
        [InlineData("joao.silva")]
        [InlineData("joao.silva@")]
        [InlineData("joao.silvacom")]
        [InlineData("joao.silva.com")]
        [InlineData("joao.silva@.com")]
        [InlineData("joao.silva@com")]
        public void Should_return_false_when_email_is_invalid(string email)
        {
            var user = new User("João da Silva", "pass", email, Profile.CBF);

            var userIsValid = user.Validate().isValid;

            Assert.False(userIsValid);
        }

        [Theory]
        [InlineData("joao.silva@gmail.com")]
        [InlineData("tiago_delas@yahoo.com")]
        [InlineData("rodrigo.dourado@bol.com.br")]
        [InlineData("rodrigo789.dourado@bol.com.br")]
        public void Should_return_true_when_email_is_valid(string email)
        {
            var user = new User("João da Silva", "pass", email, Profile.CBF);

            var userIsValid = user.Validate().isValid;

            Assert.True(userIsValid);
        }
    }
}
