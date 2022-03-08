using System.Web;
using System.Web.Mvc;

namespace BasicApp
{
    public class FilterConfig
    {
        public static void REGISTERGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
