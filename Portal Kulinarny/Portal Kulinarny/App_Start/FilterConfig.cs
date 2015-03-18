using System.Web;
using System.Web.Mvc;

namespace Portal_Kulinarny
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
