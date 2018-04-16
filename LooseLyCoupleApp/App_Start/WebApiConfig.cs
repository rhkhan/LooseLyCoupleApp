
using Autofac;
using Autofac.Integration.WebApi;
using LooselyCouple.Data.Repositories;
//using Autofac;
//using Autofac.Integration.WebApi;
using LooslyCouple.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;


namespace LooseLyCoupleApp.App_Start
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

           
        }
    }
}