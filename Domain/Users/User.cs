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

        public User(string name, Profile profile, string password) : base(name)
        {
            Profile = profile;
            Password = CryptPassword(password);
        }

        private string CryptPassword(string pass)
        {
            return Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(pass));
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

        public bool PasswordEquals(string pass)
        {
            return Password == CryptPassword(pass);
        } 
    }
}
