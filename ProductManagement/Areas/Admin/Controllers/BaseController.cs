using ProductManagement.Common;
using System.Web.Mvc;
using System.Web.Routing;

namespace ProductManagement.Areas.Admin.Controllers
{
    public class BaseController : Controller
    {
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var session =(UserLogin) Session[CommonConstant.USER_SESSTION];
            if(session == null)
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "LoginAdmin", action = "Index", Area = "Admin"}));
            }
            base.OnActionExecuting(filterContext);
        }
    }
}