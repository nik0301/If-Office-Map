using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using OfficeMap.Business;
using OfficeMap.Business.Models;

namespace OfficeMap.Web.Controllers
{
    [Produces("application/json")]
    [Route("api/MapAreaApi")]
    public class MapAreaApiController : Controller
    {
        private MapDisplay MapDisplay { get; }

        public MapAreaApiController(MapDisplay mapDisplay)
        {
            MapDisplay = mapDisplay;
        }

        // GET: api/MapAreaApi
        [HttpGet]
        public IEnumerable<MapArea> Get(int floorId, string search, string types, string filters, string units)
        {
            return MapDisplay.GetMapAreas(floorId, search, types, filters, units);
        }
    }
}
