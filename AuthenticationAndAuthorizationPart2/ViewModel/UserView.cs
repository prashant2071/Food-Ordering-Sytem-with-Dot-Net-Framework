﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AuthenticationAndAuthorizationPart2.ViewModel
{
    public class UserView
    {
        public int userid { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string Fullname { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string Address { get; set; }
    }

}