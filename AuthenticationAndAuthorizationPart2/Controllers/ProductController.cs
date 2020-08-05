using AuthenticationAndAuthorizationPart2.Models;
using AuthenticationAndAuthorizationPart2.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AuthenticationAndAuthorizationPart2.Controllers
{
    public class ProductController : Controller
    {
        NepalDBEntities db = new NepalDBEntities();

        // GET: Product
        public ActionResult ManageProduct()
        {
            return View();
        }
        public JsonResult GetData()
        {

            db.Configuration.LazyLoadingEnabled = false;
            List<ProductView> lstitem = new List<ProductView>();
            var lst = db.tblProducts.Include("tblCatagory").ToList();
            foreach (var item in lst)
            {
                lstitem.Add(new ProductView() { ProductId = item.ProductId, CatagoryName = item.tblCatagory.CatagoryName, ProductName = item.ProductName,Price = item.Price, Photo = item.Photo });
            }
            return Json(new { data = lstitem }, JsonRequestBehavior.AllowGet);

        }
        [HttpGet]
        public ActionResult AddOrEdit(int id = 0)
        {
            if (id == 0)
            {

                ViewBag.Catagory = db.tblCatagories.ToList();

                return View(new ProductView());

            }
            else
            {


                ViewBag.Catagory = db.tblCatagories.ToList();
                tblProduct tb = db.tblProducts.Where(a => a.ProductId == id).FirstOrDefault();
                ProductView tt = new ProductView();
                tt.ProductId = tb.ProductId;
                tt.CatagoryId = tb.CatagoryId;
                tt.Price = tb.Price;
                tt.ProductName = tb.ProductName;
                tt.Photo = tb.Photo;
                tt.Description = tb.Description;
                tt.IsSpecial = tb.IsSpecial;
                tt.DiscountPrice = tb.DiscountPrice;
                return View(tt);

            }
        }

        [HttpPost]

        public ActionResult AddOrEdit(ProductView ivm)
        {

            if (ivm.ProductId == 0)
            {
                tblProduct itm = new tblProduct();

                itm.CatagoryId = Convert.ToInt32(ivm.CatagoryId);
                itm.ProductName = ivm.ProductName;
                itm.Price = ivm.Price;
                itm.DiscountPrice = ivm.DiscountPrice;

                itm.Description = ivm.Description;
                itm.IsSpecial = ivm.IsSpecial;

                HttpPostedFileBase fup = Request.Files["Photo"];
                if (fup != null)
                {
                    if (fup.FileName != "")
                    {
                        fup.SaveAs(Server.MapPath("~/ProductImage/" + fup.FileName));
                        itm.Photo = fup.FileName;
                    }
                }


                db.tblProducts.Add(itm);
                db.SaveChanges();
                ViewBag.Message = "Created Successfully";
            }
            else
            {
                tblProduct itm = db.tblProducts.Where(i => i.ProductId == ivm.ProductId).FirstOrDefault();
                itm.CatagoryId = Convert.ToInt32(ivm.CatagoryId);
                itm.ProductName = ivm.ProductName;
                itm.Price = ivm.Price;
                itm.Description = ivm.Description;
                itm.IsSpecial = ivm.IsSpecial;
                itm.DiscountPrice = ivm.DiscountPrice;
                HttpPostedFileBase fup = Request.Files["Photo"];
                if (fup != null)
                {
                    if (fup.FileName != "")
                    {
                        System.IO.File.Delete(Server.MapPath("~/ProductImage/" + fup.FileName));
                        fup.SaveAs(Server.MapPath("~/ProductImage/" + fup.FileName));
                        itm.Photo = fup.FileName;
                    }
                }



                db.SaveChanges();
                ViewBag.Message = "Updated Successfully";

            }
            ViewBag.Catagory = db.tblCatagories.ToList();
            return View(new ProductView());




        }

        [HttpPost]

        public ActionResult Delete(int id)
        {

            tblProduct sm = db.tblProducts.Where(x => x.ProductId == id).FirstOrDefault();
            db.tblProducts.Remove(sm);
            db.SaveChanges();
            return Json(new { success = true, message = "Deleted Successfully" }, JsonRequestBehavior.AllowGet);

        }

    }
}