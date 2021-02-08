using System.Collections.Generic;
using System.Text.RegularExpressions;
using Domain.People;

namespace Domain.Users
{
    public class User : Person
    {
        public UserProfile Profile { get; set; }
        public string Password { get; set; }
        // Transformar em VO
        public string Email { get; set; }

        public User(string name, string password, string email, UserProfile profile) : base(name)
        {
            Password = password;
            Email = email;
            Profile = profile;
        }

        private bool ValidateEmail()
        {
            return Regex.IsMatch(
                Email,
                @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z",
                RegexOptions.IgnoreCase
            );

            // try
            // {
            //     MailAddress m = new MailAddress(Email);

            //     return true;
            // }
            // catch (FormatException)
            // {
            //     return false;
            // }
        }

        public (IList<string> errors, bool isValid) Validate()
        {
            var errors = new List<string>();
            if (!ValidateName())
            {
                errors.Add("Nome inválido.");
            }

            if (!ValidateEmail())
            {
                errors.Add("Email inválido.");
            }

            return (errors, errors.Count == 0);
        }
    }
}