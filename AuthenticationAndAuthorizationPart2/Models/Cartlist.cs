using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AuthenticationAndAuthorizationPart2.Models
{
    public class Cartlist
    {
        public static List<tblCart> GetAllCartList(int id)
        {
            using (var obj = new NepalDBEntities())
            {
                return obj.tblCarts.Where(x => x.UserId == id).ToList();

            }
        }
    }
}