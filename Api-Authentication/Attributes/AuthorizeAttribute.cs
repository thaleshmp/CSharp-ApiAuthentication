﻿using System.Web;
using System.Web.Http.Controllers;
using System.Web.Mvc;

namespace Api_Authentication.Attributes
{
    public class AuthorizeAttribute : System.Web.Http.AuthorizeAttribute
    {
        protected override void HandleUnauthorizedRequest(HttpActionContext actionContext)
        {
            if (!HttpContext.Current.User.Identity.IsAuthenticated)
            {
                base.HandleUnauthorizedRequest(actionContext);
            }
            else
            {
                actionContext.Response = new System.Net.Http.HttpResponseMessage(System.Net.HttpStatusCode.Forbidden);
            }
            base.HandleUnauthorizedRequest(actionContext);
        }
    }
}