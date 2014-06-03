using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CSEmployerMVC.Classes
{
    public class SimpleMembershipAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            //redirect if not authenticated
            if (filterContext.HttpContext.Session["myApp-Authentication"] == null ||
                filterContext.HttpContext.Session["myApp-Authentication"] != "123")
            {
                //use the current url for the redirect
                string redirectOnSuccess = filterContext.HttpContext.Request.Url.AbsolutePath;

                //send them off to the login page
                string redirectUrl = string.Format("?ReturnUrl={0}", redirectOnSuccess);
                string loginUrl = "/Employer/SignIn" + redirectUrl;
                
                filterContext.HttpContext.Response.Redirect(loginUrl, true);
            }
        }
    }
}