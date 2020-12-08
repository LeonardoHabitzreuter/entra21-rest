using System;
using System.Collections.Generic;
using Domain.People;

namespace Domain.Users
{
    public class User : Person
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Profile Profile { get; set; }
        public string Password { get; set; }
        // Transformar em VO
        public string Email { get; set; }

        public User(string name, string password, string email, Profile profile) : base(name)
        {
            Password = password;
            Email = email;
            Profile = profile;
        }

        public (IList<string> errors, bool isValid) Validate()
        {
            var errors = new List<string>();
            if (!ValidateName())
            {
                errors.Add("Nome inválido.");
            }
            return (errors, errors.Count == 0);
        }
    }
}
