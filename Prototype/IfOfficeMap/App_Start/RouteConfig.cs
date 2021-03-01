using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace IfOfficeMap
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Search",
                url: "Person/Search/{searchKey}",
                defaults: new { controller = "Person", action = "Search", searchKey = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Lookup",
                url: "Person/Lookup/{searchKey}",
                defaults: new { controller = "Person", action = "Lookup", searchKey = UrlParameter.Optional }
            );


            routes.MapRoute(
              name: "Search2",
              url: "utility/Search/{searchKey}",
              defaults: new { controller = "Utility", action = "Search", searchKey = UrlParameter.Optional }
          );

            routes.MapRoute(
            name: "PersonWorkplace",
            url: "Person/Workplace/{workplaceId}",
            defaults: new { controller = "Person", action = "Workplace", workplaceId = UrlParameter.Optional }
        );


            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Map", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
