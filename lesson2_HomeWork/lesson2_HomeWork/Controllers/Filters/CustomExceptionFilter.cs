using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace lesson2_HomeWork.Controllers.Filters
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class CustomExceptionFilter
        : Attribute, IExceptionFilter
    {
        private string _message;
        public CustomExceptionFilter(string message)
        {
            _message = message;
        }
        public void OnException(ExceptionContext filterContext)
        {
            filterContext.ExceptionHandled = true;
            filterContext.Result = new JsonResult { Data = _message };
        }
    }
}