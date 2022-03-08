using BasicApp.DAL;
using BasicApp.Models;
using BasicApp.ViewModels;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace BasicApp.Controllers
{
    public class HomeController : Controller
    {
        BasicAppContext db = new BasicAppContext();
        public ActionResult Index()
        {
            if (Session["USERNAME"] == null)
            {
                return RedirectToAction("login", "login");
            }
            var pageMetaDetail = db.PageMetaDetail.FirstOrDefault(a => a.PageUrl == "Home/Index");
            if (pageMetaDetail != null)
            {
                ViewBag.metadescription = pageMetaDetail.MetaDescription;
                ViewBag.metakeywords = pageMetaDetail.MetaKeywords;
            }

            return View();
        }
        public ActionResult Contact()
        {
            var pageMetaDetail = db.PageMetaDetail.FirstOrDefault(a => a.PageUrl == "Home/Contact");
            if (pageMetaDetail != null)
            {
                ViewBag.metadescription = pageMetaDetail.MetaDescription;
                ViewBag.metakeywords = pageMetaDetail.MetaKeywords;
            }
            return View();
        }
        [HttpPost]
        public ActionResult Contact(FormCollection FC)
        {
            string name = "", email = "", mobile = "", message = "";
            if (FC.AllKeys.Contains("name"))
            {
                name = FC["name"].ToString();
            }
            if (FC.AllKeys.Contains("email"))
            {
                email = FC["email"].ToString();
            }
            if (FC.AllKeys.Contains("mobile"))
            {
                mobile = FC["mobile"].ToString();
            }
            if (FC.AllKeys.Contains("message"))
            {
                message = FC["message"].ToString();
            }
            Connection Cn = new Connection();
            StringBuilder sb = new StringBuilder();
            sb.Append("<p><b>Name:</b> " + name + "<br/>");
            sb.Append("<b>Email:</b> " + email + "<br/>");
            sb.Append("<p><b>Mobile:</b> " + mobile + "<br/><br/>");
            sb.Append("<b>Message:</b> " + message + "<p><br/>");
            if (Cn.SendEmail("test@example.com", "Contact Us", sb.ToString(), null) == "p")
            {
                ViewData["successmessage"] = "<script>alert('Email sent Successfully to test@example.com');</script>";
                return View();
            }
            else
            {
                var ty = Cn.SendEmail("test@example.com", "Contact Us", sb.ToString(), null);
                ViewData["successmessage"] = "<script>alert('" + ty + "');</script>";

            }
            return View();
        }
        public ActionResult GetAdvertisement()
        {
            try
            {
                BasicAppContext db = new BasicAppContext();
                var ty = db.Advertisements.ToList();
                var rndGen = new Random();
                int random = rndGen.Next(0, ty.Count);
                var tyy = ty.ElementAt(random);
                return Content(tyy.Description);
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
        }
    }
}