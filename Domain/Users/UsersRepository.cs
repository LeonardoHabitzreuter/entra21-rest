using System.Collections.Generic;
using Domain.Infra;

namespace Domain.Users
{
    static class UsersRepository
    {
        private static List<User> _users = new List<User>();
        public static IReadOnlyCollection<User> Users => _users;

        public static void Add(User user)
        {
            using (var db = new BrasileiraoContext())
            {
                db.Users.Add(user);
                db.SaveChanges();
            }
        }
    }
}
