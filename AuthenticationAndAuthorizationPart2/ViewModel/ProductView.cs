using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AuthenticationAndAuthorizationPart2.ViewModel
{
    public class ProductView
    {
        [DisplayName("Catagory Name")]
        public string CatagoryName { get; set; }
        public int ProductId { get; set; }
        public Nullable<int> CatagoryId { get; set; }

        public string ProductName { get; set; }
        public string Description { get; set; }

        public Nullable<int> Price { get; set; }
        public Nullable<int> DiscountPrice { get; set; }

        [Required]
        public string Photo { get; set; }
        public bool? IsSpecial { get; set; }



    }
}