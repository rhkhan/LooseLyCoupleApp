using LooselyCouple.Data.DTO;
using LooselyCouple.Model.Models;
using LooslyCouple.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LooseLyCoupleApp.Controllers.API
{
    [RoutePrefix("api")]
    public class PermissionApiController : ApiController
    {
        private IPermissionService permissionService;

        public PermissionApiController(IPermissionService iPermissionService)
        {
            this.permissionService = iPermissionService;
        }

        // GET api/<controller>
        [HttpGet]
        [Route("permission/GetAll")]
        public IEnumerable<Permission> getPermissionList()
        {
            IEnumerable<Permission> allPermissions;
            allPermissions = permissionService.GetPermissions();
            return allPermissions;
        }

        // GET api/<controller>/5
        [HttpGet]
        [Route("permission/edit/{id}")]
        public HttpResponseMessage Get(int id)
        {
            var p = permissionService.GetPermissionById(id);
            if (p == null) throw new HttpResponseException(HttpStatusCode.NotFound);
            return Request.CreateResponse<Permission>(HttpStatusCode.OK, p);
        }

        // POST api/<controller>
        [HttpPost]
        [Route("permission/add")]
        public void Post(HttpRequestMessage request, Permission per)
        {
            if (per != null) {
                permissionService.Create(per);
                permissionService.SavePermission();
            }
        }

        // PUT api/<controller>/5
        [HttpPut]
        [Route("permission/{id}")]
        public void Put(Permission p)
        {
            permissionService.UpdatePermission(p);
            permissionService.SavePermission();
        }

        // DELETE api/<controller>/5
        [HttpDelete]
        [Route("permission/delete/{id}")]
        public void Delete(int id)
        {
            var p = permissionService.GetPermissionById(id);
            permissionService.DeletePermission(p);
            permissionService.SavePermission();
        }


        [HttpGet]
        [Route("permission/permissionStat/{id}")]
        public IEnumerable<PermissionWithStateByRoleDTO> GetpermissionStat(int id)
        {
            var p = permissionService.GetPermissionWithStateByRole(id);
            return p;
        }

    }
}