using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace LooseLyCoupleApp
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "HomeCatchAllRoute",
                url: "Home/{*.}",
                defaults: new{controller = "Home",action = "Index",id = UrlParameter.Optional}
            );

            routes.MapRoute(
                name: "RolesCatchAllRoute",
                url: "Role/{*.}",
                defaults: new{controller = "Home",action = "Index",id = UrlParameter.Optional}
           );

            routes.MapRoute(
                name: "RegisterCatchAllRoute",
                url: "Register/{*.}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
           );

            routes.MapRoute(
                name:"PermissionCatchAllRoute",
                url:"Permission/{*.}",
                defaults: new { controller="Home",action="Index",id=UrlParameter.Optional}
                );

            routes.MapRoute(
                name:"AppointmentCatchAllRoute",
                url:"Appointment/{*.}",
                defaults:new { Controller="Home",action="Index",id=UrlParameter.Optional}
                );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
