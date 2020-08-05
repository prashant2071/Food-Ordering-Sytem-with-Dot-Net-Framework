using AuthenticationAndAuthorizationPart2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AuthenticationAndAuthorizationPart2.Models
{
    public static class ItemDB
    {
        //mathi kina nepalDbEntities nalekheko ho vane  static xa so
        public static List<tblProduct> GetAllSpecialProduct()
        {
            using (var obj = new NepalDBEntities())
            {
                return obj.tblProducts.OrderByDescending(x=>x.ProductId).Where(a => a.IsSpecial == true).Take(8).ToList();

            }
        }
        public static List<tblProduct> GetAllProduct()
        {
            using (var obj = new NepalDBEntities())
            {
                return obj.tblProducts.Take(12).ToList();

            }
        }
    }
}