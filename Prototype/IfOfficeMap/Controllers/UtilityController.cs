using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IfOfficeMap.DataAccess.Database;
using IfOfficeMap.DataAccess;

namespace IfOfficeMap.Controllers
{
    public class UtilityController : Controller
    {
        private DbContext context;
        public UtilityController()
        {
            context = new DbContext("DefaultConnection");
        }

        // GET: Utility
        public ActionResult Index()
        {
            return Json(context.Utilities.ToList(), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public void Add(Utilities newUtility)
        {
            context.Utilities.Add(new Utilities()
            {
                ID = Guid.NewGuid(),
                PositionY = newUtility.PositionY,
                PositionX = newUtility.PositionX,
                Name = newUtility.Name,
                PlaceType = newUtility.PlaceType
            });
            context.Utilities.AddOrUpdate();
            context.SaveChanges();
        }

        [Route("[action]/{searchKey:int}")]
        public ActionResult Search(string searchkey)
        {
            return Json(context.Utilities.Where(x => x.Name.ToLower().Contains(searchkey.ToLower())),JsonRequestBehavior.AllowGet);
        }
    }
}