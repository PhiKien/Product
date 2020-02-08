using ProductManagement.Common;
using System.Web.Mvc;
using System.Web.Routing;

namespace ProductManagement.Controllers
{
    public class BaseController : Controller
    {
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var session =(UserLogin) Session[CommonConstant.USER_SESSTION];
            if(session == null)
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Login", action = "Index"}));
            }
            base.OnActionExecuting(filterContext);
        }
    }
}