
using AutoMapper;
using LooselyCouple.Model.Models;
using LooselyCouple.Model.Validations;
using LooseLyCoupleApp.ViewModels;
using LooslyCouple.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;


namespace LooseLyCoupleApp.Controllers.API
{
    [RoutePrefix("api")]
    public class RoleApiController : ApiController
    {
        private IAspRolesService roleService;


        public RoleApiController(IAspRolesService iAspRoleService)
        {
            this.roleService = iAspRoleService;
        }

        // GET api/RoleApi
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/RoleApi
        [HttpGet]
        [Route("roles")]
       // [Authorize(Roles = "Administration")]
        public IEnumerable<AspRolesViewModel> getRoleList()
        {
            IEnumerable<AspRoles> allRoles;
            IEnumerable<AspRolesViewModel> viewModelRoles;

            allRoles = roleService.GetRoles();
            viewModelRoles = Mapper.Map<IEnumerable<AspRoles>, IEnumerable<AspRolesViewModel>>(allRoles);
            return viewModelRoles;
        }

        // GET api/RoleApi/5
        
        [HttpGet]
        [Route("roles/{id}")]
        public HttpResponseMessage Get(int id)
        {
            var role = roleService.GetRole(id);
            if (role == null) throw new HttpResponseException(HttpStatusCode.NotFound);
            return Request.CreateResponse<AspRoles>(HttpStatusCode.OK, role);
        }

        // POST api/<controller>
        [HttpPost]
        [Route("roles")]
       // public void Post(HttpRequestMessage request, AspRolesFormViewModel newRole)
        //public HttpResponseMessage Post(HttpRequestMessage request, AspRolesFormViewModel newRole)
        public async Task<IHttpActionResult> Post(HttpRequestMessage request, AspRolesFormViewModel newRole)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);

                /* ########### If I use HttpResponseMessage
                var errors = new List<string>();
                foreach (var state in ModelState)
                {
                    foreach (var error in state.Value.Errors)
                    {
                        errors.Add(error.ErrorMessage);
                    }
                }
                return Request.CreateResponse(HttpStatusCode.Forbidden, errors);
               */
            }
            else {
                if (newRole != null)
                {
                    var role = Mapper.Map<AspRolesFormViewModel, AspRoles>(newRole);
                    roleService.CreateRoles(role);
                    roleService.Save();
                }
                //return Request.CreateResponse(HttpStatusCode.Created, newRole); // If i use HttpResponseMessage
                return Ok();
            }
        }

        // PUT api/<controller>/5
        [HttpPut]
        [Route("roles/{id}")]
        public void Put(int id, AspRoles role)
        {
            //int sx = id;
            roleService.UpdateRoles(role);
            roleService.Save();

        }

        // DELETE api/<controller>/5
        [HttpDelete]
        [Route("roles/{id}")]
        public void Delete(int id)
        {
            var role = roleService.GetRole(id);
            roleService.DeleteRole(role);
            roleService.Save();
        }

        [HttpPost]
        [Route("roles/AddPermissionToRole")]
        public void SaveRolePermission(RolePermission pr)
        {
            if (pr != null)
            {
                roleService.addPermissionToRole(pr);
                roleService.Save();
            }
        }

        [HttpDelete]
        [Route("roles/RemovePermissionFromRole")]
        public void RemoveRolePermission([FromUri] RolePermission p)
        {
           
            if (p != null)
            {
                roleService.removePermissionFromRole(p);
                roleService.Save();
            }
        }

        //[HttpDelete]
        //[Route("roles/RemovePermissionFromRole/{id}")]
        //public HttpResponseMessage DeleteWithRequestBody(int id, [FromBody] RolePermission p)
        //{
        //    if (p != null)
        //    {
        //        roleService.removePermissionFromRole(p);
        //        roleService.Save();
        //    }
        //    var response = Request.CreateResponse(HttpStatusCode.OK, p);
        //    return response;
        //}


    }
}