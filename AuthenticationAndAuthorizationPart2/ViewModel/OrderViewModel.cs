using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AuthenticationAndAuthorizationPart2.ViewModel
{
    public class OrderViewModel
    {
        public int OrderId { get; set; }
        public int UserId { get; set; }
        public string ProductName { get; set; }
        public int Price { get; set; }
        public int Photo { get; set; }
        public decimal Total { get; set; }



    }
}