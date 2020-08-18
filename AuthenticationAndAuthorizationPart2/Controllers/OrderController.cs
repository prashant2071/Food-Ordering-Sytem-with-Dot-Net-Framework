using AuthenticationAndAuthorizationPart2.Models;
using AuthenticationAndAuthorizationPart2.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AuthenticationAndAuthorizationPart2.Controllers
{
    public class OrderController : Controller
    {
        NepalDBEntities db = new NepalDBEntities();
        // GET: Order

        public ActionResult ManageOrder()
        {
            return View();
        }
        public JsonResult GetData()
        {

            db.Configuration.LazyLoadingEnabled = false;
            List<OrderViewModel> lstitem = new List<OrderViewModel>();
            var lst = db.tblOrders.Include("tblUser").ToList();
            foreach (var item in lst)
            {
                lstitem.Add(new OrderViewModel() { UserId=item.UserId.Value, FullName = item.tblUser.Fullname, Address = item.tblUser.Address, PhoneNumber = item.tblUser.PhoneNumber, Total = item.Total.Value });
            }
            return Json(new { data = lstitem }, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult itemShow(int id)
        {
            db.Configuration.LazyLoadingEnabled = false;
            List<tblCart> lst = db.tblCarts.Where(a => a.UserId == id).ToList();
            List<OrderItemView> lstitem = new List<OrderItemView>();

            foreach (var item in lst)
            {
                lstitem.Add(new OrderItemView() { ProductName = item.ProductName, photo = item.Photo, price = item.DiscountPrice.Value });
            }
            return View(lstitem);
            }

           
        
        [HttpGet]
        public ActionResult AddOrEdit(int id)
        {
            List<tblCart> tb = db.tblCarts.Where(a => a.UserId == id).ToList();
           
            return View(tb);

            
        }

     
    }
}