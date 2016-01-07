using System;
using System.Web.Mvc;
using AutoMapper;
using Learning.AutoMapper.Models;
using Learning.AutoMapper.Repository;

namespace Learning.AutoMapper.Controllers
{
    public class PersonController : Controller
    {
        // GET: Person
        [AutoMapFilter(typeof(Person), typeof(PersonViewModel))]
        public ActionResult Index()
        {
            using (var personRepo = new PersonRepository())
            {
                var persons = personRepo.Get();
                return View(persons);
            }
        }
    }

    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
    public class AutoMapFilterAttribute : ActionFilterAttribute
    {
        public Type SourceType { get; }
        public Type DestType { get; }

        public AutoMapFilterAttribute(Type sourceType, Type destType)
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
        }
    }
}