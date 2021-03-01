using Microsoft.AspNetCore.Mvc;

namespace OfficeMap.Web.Controllers
{
    public class ErrorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}