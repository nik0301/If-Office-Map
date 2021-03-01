using System.Net;
using Microsoft.AspNetCore.Mvc;
using OfficeMap.Business;
using OfficeMap.Business.Models;
using Authorization = OfficeMap.Business.Authorization;

namespace OfficeMap.Web.Controllers
{
    public class DetailsController : Controller
    {
        private readonly MapDisplay mapDisplay;
        private readonly LyncDataDisplay lyncDataDisplay;
        private readonly WorkplaceSwitch workplaceSwitch;
        private readonly Authorization authorization;

        public DetailsController(MapDisplay mapDisplay, LyncDataDisplay lyncDataDisplay, WorkplaceSwitch workplaceSwitch, Authorization authorization)
        {
            this.mapDisplay = mapDisplay;
            this.lyncDataDisplay = lyncDataDisplay;
            this.workplaceSwitch = workplaceSwitch;
            this.authorization = authorization;
        }

        // GET: Details/Index/5
        public IActionResult Get(int id)
        {
            var model = mapDisplay.GetObjectDetails(id, User.Identity.Name);

            return PartialView("DetailsPartialView", model);
        }

        // GET: Details/WorkplaceData/5
        public IActionResult WorkplaceData(int id)
        {
            var isEmployeesWorkplace = workplaceSwitch.IsEmployeesWorkplace(id, User.Identity.Name);

            if (!workplaceSwitch.IsWorkplace(id))
            {
                return Ok();
            }

            var workplaceChanges = workplaceSwitch.GetWorkplaceChanges(id);

            var workplaceData = new WorkplaceData
            {
                ObjectId = id,
                WorkplaceChanges = workplaceChanges,
                IsSuperUser = authorization.IsSuperUser(User.Identity.Name),
                IsEmployeesWorkplace = isEmployeesWorkplace,
                IsFreeWorkplace = workplaceSwitch.IsFreeWorkplace(id)
            };

            return PartialView("WorkplaceDataPartialView", workplaceData);
        }

        // GET: Details/WorkplaceEmployeeSet/5
        public IActionResult WorkplaceEmployeeSet(int id)
        {
            var model = workplaceSwitch.GetWorkplaceEmployeeSetData(id);

            return PartialView("WorkplaceEmployeeSetPartialView", model);
        }

        // POST: Details/WorkplaceEmployeeSet
        [HttpPost]
        public IActionResult WorkplaceEmployeeSet(int id, int employeeId)
        {
            try
            {
                workplaceSwitch.SetWorkplaceEmployee(id, employeeId, User.Identity.Name);
                return Ok();
            }
            catch (OfficeMapException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        // POST: Details/ReleaseWorkplace
        [HttpPost]
        public IActionResult ReleaseWorkplace(int id)
        {
            try
            {
                workplaceSwitch.ReleaseWorkplace(id, User.Identity.Name);
                return Ok();
            }
            catch (OfficeMapException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        // GET: Details/EmployeeStatus/test@if.lv
        public string EmployeeStatus(string email)
        {
            return lyncDataDisplay.GetLyncStatus(email);
        }

        // GET: Details/SendPropose/5
        public IActionResult SendProposal(int id)
        {
            try
            {
                workplaceSwitch.WorkplaceChangePropose(id, User.Identity.Name);
                return Ok();
            }
            catch (OfficeMapException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        // POST: Details/AcceptRequirement
        [HttpPost]
        public IActionResult AcceptProposal(int id)
        {
            try
            {
                workplaceSwitch.Accept(id, User.Identity.Name);
                return Ok();
            }
            catch (OfficeMapException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        // POST: Details/DeclineRequirement
        [HttpPost]
        public IActionResult DeclineProposal(int id)
        {
            try
            {
                workplaceSwitch.Decline(id, User.Identity.Name);
                return Ok();
            }
            catch (OfficeMapException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }
    }
}
