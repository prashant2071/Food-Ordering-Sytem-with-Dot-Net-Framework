using AuthenticationAndAuthorizationPart2.Models;
using AuthenticationAndAuthorizationPart2.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AuthenticationAndAuthorizationPart2.Controllers
{
    public class ShoppingController : Controller
    {
        NepalDBEntities db = new NepalDBEntities();
        // GET: Shopping
        [Authorize]
        public ActionResult CartView()
        {
            return View();
        }

        [Authorize]
        public ActionResult shop(int id)
        {
            tblProduct tb = db.tblProducts.Where(a => a.ProductId == id).FirstOrDefault();
            tblCart tbc = new tblCart();
            var tb1 = db.tblCarts.Where(a => a.ProductId == id).FirstOrDefault();
            if (tb1 != null)
            {
                db.SaveChanges();
                return Json(new { success = true, message = "Food has been already to cart", JsonRequestBehavior.AllowGet });


            }
            else
            {
                tbc.ProductId = tb.ProductId;
                tbc.UserId = Convert.ToInt32(Menu.userid);
                tbc.Date = DateTime.Today.Date;
                db.tblCarts.Add(tbc);
                db.SaveChanges();


                return Json(new { success = true, message = "Added to cart Successfully", JsonRequestBehavior.AllowGet });
            }
        }
       
        //[HttpPost]
        //public ActionResult Checkout()
        //{
        //    return View();
        //}
        //[HttpPost]
        //public ActionResult checkout(tblCart)
        //{
        //    return View();
        //}
        [HttpPost]
        public ActionResult RemoveFromCart(int id)
        {
            tblCart tb = db.tblCarts.Where(a=>a.CartId==id).FirstOrDefault();
            db.tblCarts.Remove(tb);
            db.SaveChanges();
            string productName = tb.ProductName;
            var results = new RemovefromcartviewModel
            {
                Message = Server.HtmlEncode(productName) +
                 " has been removed from your shopping cart.",

                DeleteId = id
            };
            return Json(results, JsonRequestBehavior.AllowGet );
        }
        public ActionResult Quan(int id)
        {
            var results = new QuantityViewModel
            {

                message = "Quantity must be more then 0 and less than 21",
                CartId = id
            };
            return Json(results, JsonRequestBehavior.AllowGet);
        }

        public ActionResult idcollect()
        {
            var result = db.tblCarts.Where(a => a.UserId == Convert.ToInt32(Menu.userid)).ToList().Select(x => x.CartId); // if have to select only one thing from  the list then syntax is .Select

            return Json(result, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult checkout(tblOrder tb1)
        {
            tblOrder tb = new tblOrder();
            //tb.Quantity= Convert.ToInt32(Menu.userid);
            List<tblCart> obj = db.tblCarts.Where(a => a.UserId == Convert.ToInt32(Menu.userid)).ToList(); // if have to select only one thing from  the list then syntax is .Select
            foreach (var item in obj)
            {
                tb.CartId = Convert.ToInt32(item.CartId);
                db.tblOrders.Add(tb);
            }
            return Json(db.SaveChanges(), Url.Action("Index", "Home"), JsonRequestBehavior.AllowGet);
        }
    }
}
    
