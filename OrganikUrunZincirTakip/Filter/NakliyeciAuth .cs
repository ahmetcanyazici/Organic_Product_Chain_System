using System.Web;
using System.Web.Mvc;

namespace OrganikUrunZincirTakip.Filter
{
    public class NakliyeciAuth : FilterAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            if (HttpContext.Current.Session["KisiId"] != null || HttpContext.Current.Session["RoleId"].ToString() == "1")
            {
                return;
            }
            if (HttpContext.Current.Session["KisiId"] == null || HttpContext.Current.Session["RoleId"].ToString() != "3")
            {
                filterContext.Result = new RedirectResult("/Home/Login");
            }
        }
    }
}