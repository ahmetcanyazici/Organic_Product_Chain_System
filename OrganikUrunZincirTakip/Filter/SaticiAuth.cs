﻿using System.Web;
using System.Web.Mvc;

namespace OrganikUrunZincirTakip.Filter
{
    public class SaticiAuth : FilterAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            if (HttpContext.Current.Session["KisiId"] != null || HttpContext.Current.Session["RoleId"].ToString() == "1")
            {
                return;
            }
            if (HttpContext.Current.Session["KisiId"] == null || HttpContext.Current.Session["RoleId"].ToString() != "4")
            {
                filterContext.Result = new RedirectResult("/Home/Login");
            }
        }
    }
}