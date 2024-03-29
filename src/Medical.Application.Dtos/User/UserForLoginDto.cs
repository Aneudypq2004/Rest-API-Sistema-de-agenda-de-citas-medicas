﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medical.Application.Dtos.User
{
    public class UserForLoginDto
    {
        [EmailAddress(ErrorMessage = "The email is not valid")]
        public string? Email { get; set; }

        [MinLength(8, ErrorMessage = "The password must have 8 digit")]
        public string? Password { get; set; }
    }
}
