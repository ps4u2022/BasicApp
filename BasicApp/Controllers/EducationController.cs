using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BasicApp.DAL;

namespace BasicApp.Controllers
{
    public class EducationController : Controller
    {
        BasicAppContext db = new BasicAppContext();
        // GET: Education
        public ActionResult Index()
        {
            var pageMetaDetail = db.PageMetaDetail.FirstOrDefault(a => a.PageUrl == "Education/Index");
            if (pageMetaDetail != null)
            {
                ViewBag.metadescription = pageMetaDetail.MetaDescription;
                ViewBag.metakeywords = pageMetaDetail.MetaKeywords;
            }
            return View();
        }
    }
}