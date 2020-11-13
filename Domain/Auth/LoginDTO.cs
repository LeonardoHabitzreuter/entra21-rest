using System;
using System.Collections.Generic;

namespace Domain.Auth
{
    public class LoginDTO
    {
        public Guid Id { get; private set; }
        public IList<string> Errors { get; private set; }
        public bool IsValid { get; private set; }

        public LoginDTO(Guid id)
        {
            Id = id;
            IsValid = true;
        }

        public LoginDTO(params string[] errors)
        {
            // esta atribuição não é necessária pois isValid é false por padrão
            IsValid = false;
            Errors = errors;
        }
    }
}
