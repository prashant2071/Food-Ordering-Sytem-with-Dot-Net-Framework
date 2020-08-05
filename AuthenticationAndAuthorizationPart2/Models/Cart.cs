using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AuthenticationAndAuthorizationPart2.Models
{
    public class Cart
    {
        public static List<tblCart> GetAllCartItem(int id)
        {
            using (var obj = new NepalDBEntities())
            {
                
                obj.Configuration.LazyLoadingEnabled = false;
                return obj.tblCarts.Where(x => x.UserId==id).ToList();

            }
        }
    }
}