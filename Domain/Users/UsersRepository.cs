using System.Collections.Generic;

namespace Domain.Users
{
    static class UsersRepository
    {
        private static User _adminUser = new User("admin", Profile.CBF, "123");
        private static List<User> _users = new List<User>{_adminUser};
        public static IReadOnlyCollection<User> Users => _users;

        public static void Add(User user)
        {
            _users.Add(user);
        }
    }
}
