using AutoMapper;
using LooselyCouple.Model.Models;
using LooseLyCoupleApp.ViewModels;
using LooslyCouple.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LooseLyCoupleApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAspRolesService roleService;

        public HomeController(IAspRolesService rolesService)
        {
            this.roleService = rolesService;
        }


        public ActionResult Index()
        {
            //IEnumerable<AspRoles> allRoles;
            //IEnumerable<AspRolesViewModel> viewModelRoles;

            //allRoles = roleService.GetRoles();
            //viewModelRoles = Mapper.Map<IEnumerable<AspRoles>, IEnumerable<AspRolesViewModel>>(allRoles);
            //return View(viewModelRoles);
            return View();
        }


        //public ActionResult 

        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Create(AspRolesFormViewModel newRole)
        {
            if (newRole != null) {
                //var role = Mapper.Map<AspRoles,AspRolesFormViewModel>(newRole);
                var role = Mapper.Map<AspRolesFormViewModel, AspRoles>(newRole);
                roleService.CreateRoles(role);
                roleService.Save();
            }

            return RedirectToAction("Index");
        }
    }
}