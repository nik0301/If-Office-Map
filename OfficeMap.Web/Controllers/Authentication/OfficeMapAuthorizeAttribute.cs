using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using OfficeMap.Business;

namespace OfficeMap.Web.Controllers.Authentication
{
    public class OfficeMapAuthorizeAttribute : TypeFilterAttribute
    {
        public OfficeMapAuthorizeAttribute()
            : base(typeof(AuthorizeActionFilter))
        {
        }

        private class AuthorizeActionFilter : IAsyncActionFilter
        {
            private readonly Authorization autorization;

            public AuthorizeActionFilter(Authorization autorization)
            {
                this.autorization = autorization;
            }

            public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
            {
                var isAuthorized = autorization.IsAuthorized(context.HttpContext.User.Identity.Name);

                if (!isAuthorized)
                {
                    context.Result = new RedirectToActionResult("Index", "Error", null);
                }
                else
                {
                    await next();
                }
            }
        }
    }
}
