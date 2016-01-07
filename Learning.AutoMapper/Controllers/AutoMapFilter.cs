using System;
using System.Web.Mvc;
using AutoMapper;

namespace Learning.AutoMapper.Controllers
{
    public class AutoMapFilter : ActionFilterAttribute
    {
        public Type SourceType { get; }
        public Type DestType { get; }

        public AutoMapFilter(Type sourceType, Type destType)
        {
            SourceType = sourceType;
            DestType = destType;
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var model = filterContext.Controller.ViewData.Model;

            object viewModel = Mapper.Map(model, SourceType, DestType);

            filterContext.Controller.ViewData.Model = viewModel;
        }
    }
}