﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace BasicApp
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.REGISTERGlobalFilters(GlobalFilters.Filters);
            RouteConfig.REGISTERRoutes(RouteTable.Routes);
            BundleConfig.REGISTERBundles(BundleTable.Bundles);
        }
    }
}
