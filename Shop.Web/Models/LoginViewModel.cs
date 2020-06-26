﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Web.Models
{
    public class LoginViewModel
    {
        [Required]
        [EmailAddress]
        public string Username { get; set; }

        [Required]
        public string Password{ get; set; }
        [Required]
        public bool RememberMe { get; set; }

    }
}
