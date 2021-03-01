using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using OfficeMap.Business;
using OfficeMap.Business.Models;

namespace OfficeMap.Web.Controllers
{
    [Produces("application/json")]
    [Route("api/PathApi")]
    public class PathApiController : Controller
    {
        private MapDisplay MapDisplay { get; }

        public PathApiController(MapDisplay mapDisplay)
        {
            MapDisplay = mapDisplay;
        }

        // GET: api/PathApi
        [HttpGet]
        public IEnumerable<Path> Get(int floorId)
        {
            return MapDisplay.GetPaths(floorId);
        }
    }
}
