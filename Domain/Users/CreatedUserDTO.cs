﻿using System;
using System.Collections.Generic;

namespace Domain.Users
{
    public class CreatedUserDTO
    {
        public Guid Id { get; private set; }
        public IList<string> Errors { get; set; }
        public bool IsValid { get; set; }

        public CreatedUserDTO(Guid id)
        {
            Id = id;
            IsValid = true;
        }

        public CreatedUserDTO(IList<string> errors)
        {
            // esta atribuição não é necessária pois isValid é false por padrão
            IsValid = false;
            Errors = errors;
        }
    }
}
