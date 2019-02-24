using CoreOwin.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using System;

namespace CoreOwin.Helper
{
    /// <summary>
    ///  login olmayan kişileri direk login ekranına göndermek için kullandık
    /// </summary>
    public class LoginFilter  :  IActionFilter
    {
        
        public void OnActionExecuted(ActionExecutedContext context)
        {


        }

        public   void OnActionExecuting(ActionExecutingContext context)
        {
            string actionName = (string)context.RouteData.Values["action"];
            string controllerName = (string)context.RouteData.Values["controller"];
            var controller = (HomeController)context.Controller;
               context.HttpContext.Session.TryGetValue("token", out var result);
     
            if (result == null)
            {
                context.Result = controller.RedirectToAction("Login", "Account");
            }
 

        }


    }
}
