using LooselyCouple.Data.DTO;
using LooselyCouple.Data.Filter;
using LooselyCouple.Model.Models;
using LooseLyCoupleApp.Static;
using LooslyCouple.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace LooseLyCoupleApp.Controllers.API
{
   [RoutePrefix("api")]
    public class AccountApiController : ApiController
    {
        private IAspRolesService roleService;
        private IRegisterService registerService;
        private IUserFilter uf;
        public AccountApiController(IAspRolesService iAspRoleService,IRegisterService iRegisterService,IUserFilter userfilter)
        {
            this.roleService = iAspRoleService;
            this.registerService = iRegisterService;
            this.uf = userfilter;
        }


        // GET api/RoleApi
        [HttpGet]
        [Route("account")]
        public IEnumerable<Register> getUserList()
        {
            IEnumerable<Register> allUsers;
            allUsers = registerService.GetUsers();
            return allUsers;
        }


        // GET api/<controller>/5
        [HttpGet]
        [Route("account/{id}")]
        public IEnumerable<AspRolesDTO> GetRolesForUser(string id)
        {
            IEnumerable<AspRolesDTO> userRoles;
            userRoles = registerService.GetUserRoles(id);
            return userRoles;
        }


        [HttpGet]
        [Route("account/roles")]
        public IEnumerable<AspRoles> getRoles() {
            IEnumerable<AspRoles> allRoles;
            allRoles = roleService.GetRoles();
            return allRoles;
        }

        [HttpPost]
        [Route("account")]
        public void Post(HttpRequestMessage request, RegisterViewModel newUser) //UserRole userRole
        {
            if (newUser != null)
            {
                registerService.CreateUser(newUser);
                registerService.SaveUser();
            }

        }

        // GET api/RoleApi/5

        [HttpGet]
        [Route("account/info/{id}")]
        public HttpResponseMessage Get(string id)
        {
            var user = registerService.GetUser(id);
            if (user == null) throw new HttpResponseException(HttpStatusCode.NotFound);
            return Request.CreateResponse<Register>(HttpStatusCode.OK, user);
        }

        // PUT api/<controller>/5
        [HttpPut]
        [Route("account")]
        public void Put(HttpRequestMessage request, RegisterViewModel registerUser)
        {
            registerService.UpdateUser(registerUser);
            //registerService.UpdateUserRole(user);
            //registerService.SaveUser();
        }

        [HttpGet]
        [Route("account/getLoginData")]
        public HttpResponseMessage GetLoginData([FromUri] Register user)
        {
            if (uf.IsUser(user.Username)==false)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            List<Permission> permissions = new List<Permission>();
            permissions = uf.GetDataBaseUserRolesPermissions(user.Username,user.PasswordHash);

            CustomPermission.permissionCollection = new List<string>();
            if (permissions.Count <= 0) //throw new HttpResponseException(HttpStatusCode.NotFound);
                CustomPermission.permissionCollection.Add("No Permission");
            for (int i = 0; i < permissions.Count; i++)
                CustomPermission.permissionCollection.Add(permissions[i].PermissionDescription);

                return Request.CreateResponse(HttpStatusCode.OK, permissions);
        }

       [HttpGet]
       [Route("account/logout")]
       public void Logout(){
           CustomPermission.permissionCollection = new List<string>();
       }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}