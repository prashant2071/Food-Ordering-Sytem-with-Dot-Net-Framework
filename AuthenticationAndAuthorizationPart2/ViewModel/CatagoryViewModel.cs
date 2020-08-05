using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AuthenticationAndAuthorizationPart2.ViewModel
{
    public class CatagoryViewModel
    {
        public int CatagoryId { get; set; }
        [Required]
        public string CatagoryName { get; set; }

    }
}