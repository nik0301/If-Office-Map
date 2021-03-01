using System;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web.Mvc;
using IfOfficeMap.Business;
using IfOfficeMap.DataAccess;
using IfOfficeMap.DataAccess.Database;
using Newtonsoft.Json.Linq;

namespace IfOfficeMap.Controllers
{
    public class WorkplaceController : Controller
    {
        private DbContext context;
        public WorkplaceController()
        {
            context = new DbContext("DefaultConnection");
        }

        // GET: Workplace
        public ActionResult Index()
        {
            var places = context.Workplaces.ToList();
            var result = new JObject();
            var repo = new PersonRepository();
            var utilities = context.Utilities.ToList();
            foreach (var item in places)
            {
                var person = new Person();
                if (item.Employee != null)
                {
                    person = repo.Lookup(item.Employee.Email).FirstOrDefault();
                }
                var obj = new JObject();
                result[item.ID.ToString()] = JToken.FromObject(new
                {
                    type = "circle",
                    size = 20,
                    x = item.PositionX,
                    y = item.PositionY,
                    isTaken = person?.Email != null,
                    tooltip = new
                    {
                        content =
                                $"<span style='font-weight:bold;'><img src={person?.PhotoData}><h2>{person?.FirstName + " " + person?.LastName}</h2><br>{person?.Title}</span> <br>{person?.Available}",
                        cssClass = "customTooltip"
                    },
                    href = "#",
                    attrs = new {
                        fill= person?.ActivityColor
                    }
            });
                //result.Add(obj);
            }
            foreach (var item in utilities)
            {
                var obj = new JObject();
                result[item.ID.ToString()] = JToken.FromObject(new
                {
                    type = "square",
                    size = 20,
                    x = item.PositionX,
                    y = item.PositionY,
                    tooltip = new
                    {
                        content =
                                $"<span style='font-weight:bold;'><h2>{item.Name}</h2><br>{item.PlaceType.ToString()}</span> <br>",
                        cssClass = "customTooltip"
                    },
                    href = "#"
                });
            }
            
            return Content(result.ToString(), "application/json");
        }

        public ActionResult Search(string SearchString)
        {
            var places = context.Workplaces.Where(x => x.Employee != null && x.Employee.FirstName.ToLower().Contains(SearchString.ToLower()) ||
                                x.Employee.LastName.ToLower().Contains(SearchString.ToLower())).ToList();
            var result = new JObject();
            var repo = new PersonRepository();
            var utilities = context.Utilities.Where(x => x.Name.ToLower().Contains(SearchString.ToLower()) ||
                                (x.PlaceType.ToString().ToLower()).Contains(SearchString.ToLower())).ToList();
            foreach (var item in places)
            {
                var person = new Person();
                if (item.Employee != null)
                {
                    person = repo.Lookup(item.Employee.Email).FirstOrDefault();
                }
                var obj = new JObject();
                result[item.ID.ToString()] = JToken.FromObject(new
                {
                    type = "circle",
                    size = 20,
                    x = item.PositionX,
                    y = item.PositionY,
                    isTaken = person?.Email != null,
                    tooltip = new
                    {
                        content =
                                $"<span style='font-weight:bold;'><img src={person?.PhotoData}><h2>{person?.FirstName + " " + person?.LastName}</h2><br>{person?.Title}</span> <br>{person?.Available}",
                        cssClass = "customTooltip"
                    },
                    href = "#",
                    attrs = new
                    {
                        fill = person?.ActivityColor
                    }
                });
                //result.Add(obj);
            }
            foreach (var item in utilities)
            {
                var obj = new JObject();
                result[item.ID.ToString()] = JToken.FromObject(new
                {
                    type = "square",
                    size = 20,
                    x = item.PositionX,
                    y = item.PositionY,
                    tooltip = new
                    {
                        content =
                                $"<span style='font-weight:bold;'><h2>{item.Name}</h2><br>{item.PlaceType.ToString()}</span> <br>",
                        cssClass = "customTooltip"
                    },
                    href = "#"
                });
            }

            return Content(result.ToString(), "application/json");
        }

        public void Add(Workplace newWorkplace)
        {
            context.Workplaces.Add(new IfOfficeMap.DataAccess.Database.Workplace
            {
                ID = Guid.NewGuid(),
                Data = newWorkplace.Data,
                Note = newWorkplace.Note,
                PositionX = newWorkplace.PositionX,
                PositionY = newWorkplace.PositionY
            });
            context.Workplaces.AddOrUpdate();
            context.SaveChanges();
        }


        public void Set(Guid workPlaceId, Guid employeeId)
        {
            var user = context.Employee.FirstOrDefault(x => x.ID == employeeId);
            var place = context.Workplaces.FirstOrDefault(x => x.ID == workPlaceId);
         
            place.Employee = user;
            user.Workplace = place;
            context.SaveChangesAsync();
        }

        public void Clear(Guid workPlaceId)
        {
            var user = context.Employee.FirstOrDefault(x => x.Workplace.ID == workPlaceId);
            var place = context.Workplaces.FirstOrDefault(x => x.ID == workPlaceId);

            place.Employee = null;
            user.Workplace = null;
            context.SaveChangesAsync();
        }
    }
}