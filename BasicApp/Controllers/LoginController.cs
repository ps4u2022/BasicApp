using BasicApp.DAL;
using BasicApp.Models;
using BasicApp.ViewModels;
using System;
using System.Linq;
using System.Web.Mvc;
using System.Data;
using System.Text;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace BasicApp.Controllers
{
    public class LoginController : Controller
    {
        BasicAppContext db = new BasicAppContext();
        // GET: Login
        public ActionResult Login()
        {
            if (Session["USERNAME"] != null)
            {
                return RedirectToAction("Index", "Home");
            }
            LoginScreen VM = new LoginScreen(); 
            var pageMetaDetail = db.PageMetaDetail.FirstOrDefault(a => a.PageUrl == "Login/Index");
            if (pageMetaDetail != null)
            {
                ViewBag.metadescription = pageMetaDetail.MetaDescription;
                ViewBag.metakeywords = pageMetaDetail.MetaKeywords;
            }
            return View(VM);
        }
        [HttpPost]
        public ActionResult Login(LoginScreen VM)
        {
            BasicAppContext db = new BasicAppContext();
            string USEREMAIL = VM.USER_DETAILS.USEREMAIL;
            string PASSWORD = VM.USER_DETAILS.PASSWORD;
            var tblUser_data = db.tblUser.Where(a => a.UserId == USEREMAIL && a.Password == PASSWORD).FirstOrDefault();

            if (tblUser_data != null)
            {
                Session["USEREMAIL"] = USEREMAIL;
                Session["USERNAME"] = tblUser_data.UserName;
                if (VM.REMEMBERME == true)
                {
                    Response.Cookies["USEREMAIL"].Expires = DateTime.Now.AddDays(15);
                    Response.Cookies["PASSWORD"].Expires = DateTime.Now.AddDays(15);
                }
                else
                {
                    Response.Cookies["USEREMAIL"].Expires = DateTime.Now.AddDays(-1);
                    Response.Cookies["Password"].Expires = DateTime.Now.AddDays(-1);
                }
                ModelState.Clear();
            }
            else
            {
                ModelState.Clear();
                ModelState.AddModelError("USEREMAIL", "Wrong Username or Password Entired.");
            }
            if (!ModelState.IsValid)
            {
                return View(VM);
            }
            else
            {
                ModelState.Clear();
                return RedirectToAction("Index", "HOME");
            }
        }

        public ActionResult Registration()
        {
            LoginScreen VM1 = new LoginScreen();
            var pageMetaDetail = db.PageMetaDetail.FirstOrDefault(a => a.PageUrl == "Login/Registration");
            if (pageMetaDetail != null)
            {
                ViewBag.metadescription = pageMetaDetail.MetaDescription;
                ViewBag.metakeywords = pageMetaDetail.MetaKeywords;
            }
            if (TempData["ii"] != null)
            {
                string uid = TempData["ii"].ToString();
                BasicAppContext db = new BasicAppContext();
                var brnchidss = db.tblUser.Where(m => m.UserId == uid).FirstOrDefault();
                if (brnchidss != null)
                {
                    USER_DETAILS1 uSER_DETAILS1 = new USER_DETAILS1()
                    {
                        USERID = brnchidss.UserId,
                        FULLNAME = brnchidss.UserName,
                        PASSWORD = brnchidss.Password
                    };
                    VM1.USER_DETAILS = uSER_DETAILS1;
                }
            }
            VM1.Userdtl = USERlist();
            return View(VM1);
        }
        public ActionResult Registrationedit(string uid)
        {
            TempData["ii"] = uid;
            return RedirectToAction("Registration", "login");
        }
        public ActionResult Registrationdelete(string uid)
        {
            try
            {
                BasicAppContext db = new BasicAppContext();
                var brnchidss = db.tblUser.Where(m => m.UserId == uid).ToList();
                if (brnchidss != null)
                {
                    db.tblUser.RemoveRange(brnchidss);
                    db.SaveChanges(); LoginScreen VM1 = new LoginScreen();
                    VM1.Userdtl = USERlist();
                    return RedirectToAction("Registration", "login", VM1);
                }
            }
            catch (Exception ex)
            {
                return Json(ex.Message + ex.InnerException, JsonRequestBehavior.AllowGet);
            }
            return View(USERlist());
        }
        private List<USER_DETAILS1> USERlist()
        {
            BasicAppContext db = new BasicAppContext();
            List<USER_DETAILS1> s = new List<USER_DETAILS1>();
            var tblUser_data = db.tblUser.ToList();
            foreach (var v in tblUser_data)
            {
                s.Add(new USER_DETAILS1() { USERID = v.UserId, FULLNAME = v.UserName });
            }
            return s;
        }
        [HttpPost]
        public ActionResult Registration(LoginScreen VM)
        {
            try
            {
                BasicAppContext db = new BasicAppContext();
                var tblUser_data = db.tblUser.Where(u => u.UserId == VM.USER_DETAILS.USERID).ToList();
                using (BasicAppContext entities = new BasicAppContext())
                {
                    tblUser tblUser = new tblUser();
                    tblUser.UserId = VM.USER_DETAILS.USERID;
                    tblUser.UserName = VM.USER_DETAILS.FULLNAME;
                    tblUser.Password = VM.USER_DETAILS.PASSWORD;
                    if (tblUser_data.Count > 0)
                    {
                        entities.Entry(tblUser).State = System.Data.Entity.EntityState.Modified;
                    }
                    else
                    {
                        entities.tblUser.Add(tblUser);
                    }
                    entities.SaveChanges();
                }
                LoginScreen VM1 = new LoginScreen();
                VM1.Userdtl = USERlist();
                return View(VM);
            }
            catch (Exception e)
            {
                return Content(e.ToString());
            }
        }
        public ActionResult Logout()
        {
            Session.RemoveAll();
            ModelState.Clear();
            TempData["MSG"] = "Logout Successfully.";
            return RedirectToAction("Index", "HOME");
        }
        public ActionResult ForgotPassword()
        {
            LoginScreen VM = new LoginScreen();
            var pageMetaDetail = db.PageMetaDetail.FirstOrDefault(a => a.PageUrl == "Login/ForgotPassword");
            if (pageMetaDetail != null)
            {
                ViewBag.metadescription = pageMetaDetail.MetaDescription;
                ViewBag.metakeywords = pageMetaDetail.MetaKeywords;
            }
            return View(VM);
        }
    }
}