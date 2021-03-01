using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.Web.Routing;

namespace MvcSiteMapProvider.Filters
{
    public class RedirectAuthenticatedRequests : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (!filterContext.HttpContext.Request.IsAuthenticated)
            {
                filterContext.Result = new RedirectToRouteResult(
                    new RouteValueDictionary(new
                    {
                        controller = "Home",
                        action = "Login"
                    }
                ));
            }

            base.OnActionExecuting(filterContext);
        }
    }
}
