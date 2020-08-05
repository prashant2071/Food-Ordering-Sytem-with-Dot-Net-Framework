using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AuthenticationAndAuthorizationPart2.Models;

namespace AuthenticationAndAuthorizationPart2
{
    public class Menu
    {
        public static string userid = "";
        public static List<tblCatagory> GetCatagoryMenu()
        {
            using (var db = new NepalDBEntities())
            {
                return db.tblCatagories.ToList();
            }
        }
        //public static List<tblProduct> GetProductsMenu(int i)
        //{
        //    using (var db=new NepalDBEntities())
        //    {
        //        return db.tblProducts.Where(a => a.ProductId == i);
        //    }
        //}
    }
}