using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AuthenticationAndAuthorizationPart2.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        [Authorize]
        public ActionResult Dashboard()
        {
            return View();
        }
       
    }
}