using System;
using System.Web.Mvc;

namespace Learning.AutoMapper.Controllers
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
    public class AutoMapAttribute : ActionFilterAttribute
    {
        public Type SourceType { get; }
        public Type DestType { get; }

        public AutoMapAttribute(Type sourceType, Type destType)
        {
            SourceType = sourceType;
            DestType = destType;
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var filter = new AutoMapFilter(SourceType, DestType); 
            filter.OnActionExecuted(filterContext);
        }
    }
}