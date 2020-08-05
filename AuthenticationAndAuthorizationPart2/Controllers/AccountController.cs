using AuthenticationAndAuthorizationPart2.Models;
using AuthenticationAndAuthorizationPart2.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace AuthenticationAndAuthorizationPart2.Controllers
{
    public class AccountController : Controller
    {
        NepalDBEntities db = new NepalDBEntities();
        // GET: Account
        public ActionResult login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult login(loginView l, string ReturnUrl)
        {
            tblUser user = db.tblUsers.Where(a => a.Username == l.Username && a.Password == l.Password).FirstOrDefault();
            if (user != null)
            {
                @Session.Add("fullname", user.Fullname);
                @Session.Add("userid", user.UserId);
                Menu.userid = Convert.ToString(user.UserId);
                FormsAuthentication.SetAuthCookie(l.Username,l.RememberMe);

                if (Url.IsLocalUrl(ReturnUrl))
                {
                    return Redirect(ReturnUrl);

                }
                else
                {
                    if (user.tblUserRoles.Where(r => r.RoleId == 1 || r.RoleId==3).FirstOrDefault() != null)
                    {
                        return RedirectToAction("Dashboard", "Admin");
                    }
                    else
                    {
                        return RedirectToAction("Index","Home");
                    }
                }
            }
            else
            {
                ViewBag.Message = "Incorrect Username and Password";
                return View();
            }
        }
        [Authorize]
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("login", "Account");
        }
        [HttpGet]
        public ActionResult ChangePassword()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ChangePassword(ChangePasswordView ch)
        {
            if (ch.NewPassword == ch.ConfirmNewPassword)
            {
                string username = User.Identity.Name;

                tblUser tb = db.tblUsers.Where(a => a.Password == ch.OldPassword && a.Username==username).FirstOrDefault();
                if (tb != null)
                {
                    tb.Password = ch.ConfirmNewPassword;
                    db.SaveChanges();
                    ViewBag.Message = "password change successfully ";

                }
                else
                {
                    ViewBag.Message = "Old password didnot match";
                }
                return View();

            }
            else
            {
                ViewBag.Message = "Password Did not match";
                return View();
            }
        }
        [HttpGet]
        public ActionResult ForgetPassword()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ForgetPassword(UserView uv)
        {
            using (MailMessage mm = new MailMessage("pbt133393@gmail.com", uv.Email))
            {
                tblUser tb = db.tblUsers.Where(a => a.Email == uv.Email).FirstOrDefault();
                if (tb != null)
                {
                    mm.Subject = "Password Recovery";
                    mm.Body = "Your Password is :" + tb.Password;

                    mm.IsBodyHtml = false;
                    using (SmtpClient smtp = new SmtpClient())
                    {
                        smtp.Host = "smtp.gmail.com";
                        smtp.EnableSsl = true;
                        NetworkCredential NetworkCred = new NetworkCredential("pbt133393@gmail.com", "AshokThapa");
                        smtp.UseDefaultCredentials = true;
                        smtp.Credentials = NetworkCred;
                        smtp.Port = 587;
                        smtp.Send(mm);
                        ViewBag.Message = "Email sent please check Your Email";
                    }
                }
                else
                {
                    ViewBag.Message = "Email doesn't Exist";
                }
            }

            return View();
        }
        public ActionResult Registration()
        {
            return View();
        }
        public JsonResult Regis(tblUser tb)
        {
            db.tblUsers.Add(tb);
            db.SaveChanges();
            tblUserRole tbl = new tblUserRole();
            tbl.UserId = tb.UserId;
            tbl.RoleId = 2;
            db.tblUserRoles.Add(tbl);
            return Json(db.SaveChanges(), JsonRequestBehavior.AllowGet);
        }
        //[HttpPost]
        //public ActionResult Registration(UserView uv)
        //{
        //    tblUser tb = new tblUser();
        //    tb.Username = uv.Username;
        //    tb.Password = uv.Password;
        //    tb.PhoneNumber = uv.PhoneNumber;
        //    tb.Email = uv.Email;
        //    tb.Fullname = uv.Fullname;
        //    tb.Address = uv.Address;
        //    db.tblUsers.Add(tb);
        //    db.SaveChanges();
        //    tblUserRole tbl = new tblUserRole();
        //    tbl.UserId = tb.UserId;
        //    tbl.RoleId = 2;
        //    db.tblUserRoles.Add(tbl);
        //    db.SaveChanges();
        //   return RedirectToAction("Index");

        //}

    }
}