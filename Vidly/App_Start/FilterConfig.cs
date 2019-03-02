using System.Web;
using System.Web.Mvc;

namespace Vidly
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            // Application Level filter
            filters.Add(new AuthorizeAttribute());
            //enable https & restrict http requests
            filters.Add(new RequireHttpsAttribute());
        }
    }
}
