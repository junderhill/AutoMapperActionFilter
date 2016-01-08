using System;
using System.Collections;
using System.Collections.Generic;
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
            object vm;
            if (model is IList && model.GetType().IsGenericType)
            {
                vm = (IList)Activator.CreateInstance(typeof(List<>).MakeGenericType(DestType));
                foreach (var o in (IList)model)
                {
                    var mappedObj = Mapper.DynamicMap(o, SourceType, DestType);
                    ((IList)vm).Add(mappedObj);
                }
            }
            else
            {
                vm = Mapper.DynamicMap(model, SourceType, DestType);
            }
            filterContext.Controller.ViewData.Model = vm;
        }
    }
}