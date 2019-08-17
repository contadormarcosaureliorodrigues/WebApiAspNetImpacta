using System.Web;
using System.Web.Mvc;

namespace Impacta.WebApi.Pessoas
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
