using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using LooselyCouple.Data.DbOperationInfrastructure;
using LooselyCouple.Data.Filter;
using LooselyCouple.Data.Repositories;
//using LooseLyCoupleApp.Autofac;
using LooseLyCoupleApp.Mappings;
using LooslyCouple.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace LooseLyCoupleApp.App_Start
{
    public static class Bootstrapper
    {
        public static void Run()
        {
            SetAutofacContainer();
            //Configure AutoMapper
            AutoMapperConfiguration.Configure();
        }

        private static void SetAutofacContainer()
        {
            ////var configuration = GlobalConfiguration.Configuration;
            HttpConfiguration config=new HttpConfiguration();

            var builder = new ContainerBuilder();
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.RegisterControllers(Assembly.GetExecutingAssembly());
            builder.RegisterType<UnitOperation>().As<IUnitOperation>().InstancePerRequest();
            builder.RegisterType<DbFactory>().As<IDbFactory>().InstancePerRequest();


            // Repositories
            builder.RegisterAssemblyTypes(typeof(AspRolesRepository).Assembly)
                .Where(t => t.Name.EndsWith("Repository"))
                .AsImplementedInterfaces().InstancePerRequest();
            builder.RegisterAssemblyTypes(typeof(RegisterRepository).Assembly)
              .Where(t => t.Name.EndsWith("Repository"))
              .AsImplementedInterfaces().InstancePerRequest();
            builder.RegisterAssemblyTypes(typeof(RolePermissionRepository).Assembly);
            builder.RegisterAssemblyTypes(typeof(AppointmentRepository).Assembly);

            // Services
            builder.RegisterAssemblyTypes(typeof(RegisterService).Assembly)
              .Where(t => t.Name.EndsWith("Service"))
              .AsImplementedInterfaces().InstancePerRequest();
            builder.RegisterAssemblyTypes(typeof(AspRolesService).Assembly)
               .Where(t => t.Name.EndsWith("Service"))
               .AsImplementedInterfaces()
               .InstancePerRequest();
            builder.RegisterAssemblyTypes(typeof(AppointmentService).Assembly)
                .Where(t => t.Name.EndsWith("Service"))
                .AsImplementedInterfaces().InstancePerRequest();

            //Filters
            builder.RegisterType<UserFilter>().As<IUserFilter>().SingleInstance(); // registering UserFilter in Autofac for injecting in AccountApiController

            IContainer container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);
           // var resolver = new AutofacWebApiDependencyResolver(container);
           // config.DependencyResolver = resolver;
        }
    }
}