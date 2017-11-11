using System.Web;
using System.Web.Mvc;

namespace BanglaBazarFoodCourt
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
