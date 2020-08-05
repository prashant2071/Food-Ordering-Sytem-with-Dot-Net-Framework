using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AuthenticationAndAuthorizationPart2.ViewModel
{
    public class loginView
    {
        public int UserId { get; set; }

        //[Required(ErrorMessage = "This feild is required")]
        public string Username { get; set; }
        public string Email { get; set; }


        [Required(ErrorMessage = "This feild is required")]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}