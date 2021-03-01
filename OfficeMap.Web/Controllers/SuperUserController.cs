using Microsoft.AspNetCore.Mvc;
using OfficeMap.Business;


namespace OfficeMap.Web.Controllers
{
    public class SuperUserController : Controller
    {
        private readonly SuperUserData superUserData;

        public SuperUserController(SuperUserData superUserData)
        {
            this.superUserData = superUserData;
        }

        public IActionResult Index(int id)
        {
            var info = superUserData.GetEmployees(User?.Identity?.Name, id);

            return View(info);
        }
    }
}
