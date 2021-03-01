using System.Linq;
using System.Web.Mvc;
using IfOfficeMap.Business;
using IfOfficeMap.DataAccess;
using Newtonsoft.Json.Linq;

namespace IfOfficeMap.Controllers
{
    public class MapController : Controller
    {
        private DbContext context;
        public MapController()
        {
            context = new DbContext("DefaultConnection");
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Map()
        {
            return View();
        }

        public ActionResult Search(string SearchString)
        {
            var places = context.Workplaces.Where(x=>x.Employee != null && x.Employee.FirstName.ToLower().Contains(SearchString.ToLower()) ||
                                x.Employee.LastName.ToLower().Contains(SearchString.ToLower())).ToList();
            var result = new JObject();
            var repo = new PersonRepository();
            var utilities = context.Utilities.Where(x=>x.Name.ToLower().Contains(SearchString.ToLower())).ToList();
            foreach (var item in places)
            {
                var person = new Person();
                if (item.Employee != null)
                {
                    person = repo.Lookup(item.Employee.Email).FirstOrDefault();
                }
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
    }
}
