using System.Web.Mvc;
using IfOfficeMap.Business;

namespace IfOfficeMap.Controllers
{
    public class StuffDirectoryController : Controller
    {
        private PersonRepository personRepository;

        public StuffDirectoryController()
        {
            personRepository = new PersonRepository();
        }

        [OutputCache(Duration = 30, VaryByParam = "none")]
        public ActionResult Index()
        {
            
                // personRepository.GetPersons().ToList();
            return View(personRepository.GetPersons());
        }
    }
}
