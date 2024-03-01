﻿using Microsoft.AspNetCore.Identity;

namespace Medical.Domain.Entities
{
    public class User : IdentityUser
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }

    }
}
