using AuthenticationAndAuthorizationPart2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;

namespace AuthenticationAndAuthorizationPart2.Controllers
{
    public class HomeController : Controller
    {
        NepalDBEntities db = new NepalDBEntities();
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ProductList(string search, int? page, int id = 0)
        {

            if (id != 0)
            {

                return View(db.tblProducts.Where(p => p.CatagoryId == id).ToList().ToPagedList(page ?? 1, 4));
            }
            else
            {
                if (search != "")
                {
                    return View(db.tblProducts.Where(x => x.Description.Contains(search) || x.ProductName.Contains(search) || search == null).ToList().ToPagedList(page ?? 1, 12));
                }
                else
                {
                    return View(db.tblProducts.ToList().ToPagedList(page ?? 1, 12));
                }

            }

        }
        public ActionResult login()
        {
            return View();
        }
        NepalDBEntities _db = new NepalDBEntities();
        public ActionResult ViewItem(int id)
        {
            return PartialView("_ViewItem", _db.tblProducts.Find(id));
        }
        public ActionResult About()
        {
            return View();
        }
        public ActionResult Contact()
        {
            return View();
        }
    }
}