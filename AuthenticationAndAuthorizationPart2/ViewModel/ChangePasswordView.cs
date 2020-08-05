using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace AuthenticationAndAuthorizationPart2.ViewModel
{
    public class ChangePasswordView
    {
        [DisplayName("Old Password")]
        public String OldPassword  { get; set; }

        [DisplayName("New Password")]
        public String NewPassword { get; set; }

        [DisplayName("Confirm New Password")]
        public String ConfirmNewPassword { get; set; }
    }
}