using System;
using System.Web;
using System.Web.Mvc;

namespace IdentityASP
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new NoCacheAttribute());
        }
    }
    //Logout web browser back button clear cache
    public class NoCacheAttribute : ActionFilterAttribute
    {
        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            filterContext.HttpContext.Response.Cache.SetExpires(DateTime.UtcNow.AddMinutes(-1));
            filterContext.HttpContext.Response.Cache.SetValidUntilExpires(false);
            filterContext.HttpContext.Response.Cache.SetRevalidation(HttpCacheRevalidation.AllCaches);
            filterContext.HttpContext.Response.Cache.SetCacheability(HttpCacheability.NoCache);
            filterContext.HttpContext.Response.Cache.SetNoStore();
            base.OnResultExecuting(filterContext);
        }
    }

    //public class CustomAttribute : ActionFilterAttribute
    //{
    //    public override void OnActionExecuting(ActionExecutingContext filterContext)
    //    {
    //        // TODO: Add your acction filter's tasks here

    //        // Log Action Filter Call
    //        //    MusicStoreEntities storeDB = new MusicStoreEntities();

    //        //    ActionLog log = new ActionLog()
    //        //    {
    //        //        Controller = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName,
    //        //        Action = filterContext.ActionDescriptor.ActionName + " (Logged By: CustomAction Filter)",
    //        //        IP = filterContext.HttpContext.Request.UserHostAddress,
    //        //    DateTime = filterContext.HttpContext.Timestamp
    //        //    };

    //        //storeDB.ActionLogs.Add(log);
    //        //storeDB.SaveChanges();
    //        base.OnActionExecuting(filterContext);
    //    }
    //}
}
