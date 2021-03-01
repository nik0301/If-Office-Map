using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OfficeMap.Business;
using OfficeMap.Web.Controllers.Authentication;

namespace OfficeMap.Web.Controllers
{
    [Authorize]
    [OfficeMapAuthorize]
    public class HomeController : Controller
    {
        private readonly FloorSwitch floorSwitch;
        private readonly LyncDataDisplay lyncDataDisplay;

        public HomeController(FloorSwitch floorSwitch, LyncDataDisplay lyncDataDisplay)
        {
            this.floorSwitch = floorSwitch;
            this.lyncDataDisplay = lyncDataDisplay;
        }

        public IActionResult Index(int? floorId = null)
        {
            var floors = floorSwitch.Get(User?.Identity?.Name, floorId);

            return View(floors);
        }

        public IActionResult GetPhoto(string id)
        {
            int maxAge;
            DateTime expires;
            byte[] photo;

            if (id == "profile.jpg")
            {
                // Cache profile images for 1 day
                maxAge = 60 * 60 * 24;
                expires = DateTime.UtcNow.AddDays(1);
                photo = lyncDataDisplay.GetLyncPhoto(User.Identity.Name);
            }
            else
            {
                // Cache another profile images for 1 month
                maxAge = 60 * 60 * 24 * 30;
                expires = DateTime.UtcNow.AddMonths(1);
                var userId = int.Parse(id.Split('.')[0]);
                photo = lyncDataDisplay.GetLyncPhoto(userId);
            }

            Response.Headers.Add("cache-control",
                new[]
                {
                    $"public,max-age={maxAge}"
                });
            Response.Headers.Add("Expires",
                new[]
                {
                    expires.ToString("R")
                }); // Format RFC1123

            return File(photo, "image/jpeg");
        }
    }
}
