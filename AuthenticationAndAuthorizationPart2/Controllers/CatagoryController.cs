using AuthenticationAndAuthorizationPart2.Models;
using AuthenticationAndAuthorizationPart2.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AuthenticationAndAuthorizationPart2.Controllers
{
    public class CatagoryController : Controller
    {
        NepalDBEntities db = new NepalDBEntities();
        // GET: Catagory
        public ActionResult ManageCatagory()
        {
            return View();
        }
        public JsonResult GetData()
        {
            db.Configuration.LazyLoadingEnabled = false;
            List<CatagoryViewModel> lst = new List<CatagoryViewModel>();
            List<tblCatagory> tb = db.tblCatagories.ToList();
            foreach (tblCatagory item in tb)
            {
                lst.Add(new CatagoryViewModel() { CatagoryId = item.CatagoryId, CatagoryName = item.CatagoryName });

            }
            return Json(new { data = lst }, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult AddOrEdit(int id = 0)
        {
            if (id == 0)
            {
                ViewBag.Action = "New Catagory";
                return View(new CatagoryViewModel());
            }

            else
            {
                CatagoryViewModel tb = new CatagoryViewModel();
                tblCatagory tbl = db.tblCatagories.Where(a => a.CatagoryId == id).FirstOrDefault();
                tb.CatagoryId = tbl.CatagoryId;
                tb.CatagoryName = tbl.CatagoryName;
                ViewBag.Action = "Edit Catagory";
                return View(tb);
            }


        }
        [HttpPost]
        public ActionResult AddOrEdit(CatagoryViewModel tb)
        {
            if (tb.CatagoryId == 0)
            {
                tblCatagory tbl = new tblCatagory();
                tbl.CatagoryId = tb.CatagoryId;
                tbl.CatagoryName = tb.CatagoryName;
                db.tblCatagories.Add(tbl);
                db.SaveChanges();
                return Json(new { success = true, message = "Saved successfully", JsonRequestBehavior.AllowGet });
                ;
            }
            else
            {
                tblCatagory tbl = db.tblCatagories.Where(x => x.CatagoryId == tb.CatagoryId).FirstOrDefault();
                tbl.CatagoryName = tb.CatagoryName;
                db.SaveChanges();
                return Json(new { success = true, message = "Updated Successfully" }, JsonRequestBehavior.AllowGet);

            }

        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            tblCatagory sm = db.tblCatagories.Where(x => x.CatagoryId == id).FirstOrDefault();
            db.tblCatagories.Remove(sm);
            db.SaveChanges();
            return Json(new { success = true, message = "Deleted Successfully" }, JsonRequestBehavior.AllowGet);

        }

    }
}
    
