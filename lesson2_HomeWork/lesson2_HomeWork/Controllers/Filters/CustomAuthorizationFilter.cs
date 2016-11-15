using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace lesson2_HomeWork.Controllers.Filters
{
    public class CustomAuthorizationFilter
        : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            

        }
    }
}