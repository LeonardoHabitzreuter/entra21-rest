using System;

namespace Domain.Users
{
    public class User
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public Profile Profile { get; set; }

        public User(string name, Profile profile)
        {
            Name = name;
            Profile = profile;
        }
    }
}
