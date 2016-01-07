using System.Web.Mvc;
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
}