using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IfOfficeMap.Business;
using IfOfficeMap.DataAccess;

namespace IfOfficeMap.Controllers
{
    [Route("[controller]")]
    public class PersonController : Controller
    {

        private DbContext context;
        public PersonController()
        {
            context = new DbContext("DefaultConnection");
        }

        [Route("[action]")]
        public JsonResult Lookup(string searchKey)
        {
            var repo = new PersonRepository();
            return Json(repo.Lookup(searchKey), JsonRequestBehavior.AllowGet);
        }

        [Route("[action]")]
        public JsonResult Index()
        {
            var repo = new PersonRepository();
            return Json(repo.GetPersons(35), JsonRequestBehavior.AllowGet);
        }

        public JsonResult Workplace(Guid workplaceId)
        {
            var repo = new PersonRepository();
            var firstOrDefault = context.Employee.FirstOrDefault(x => x.Workplace.ID == workplaceId);
            if (firstOrDefault != null)
                return Json(repo.SearchPersons(firstOrDefault.Email.ToString()), JsonRequestBehavior.AllowGet);
            else return null;
        }

        [OutputCache(Duration = 30, VaryByParam = "none")]
        [Route("[action]/{searchKey:int}")]
        public JsonResult Search(string searchKey)
        {
            var repo = new PersonRepository();
            return Json(repo.SearchPersons(searchKey), JsonRequestBehavior.AllowGet);
        }
    }
}