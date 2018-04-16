using LooseLyCoupleApp.Static;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LooseLyCoupleApp.Controllers.API
{
    [RoutePrefix("api")]
    public class ProductApiController : ApiController
    {

//        select AspNetRoles.AspRolesID,AspNetRoles.Name from AspNetRoles, AspNetRolePermission,AspNetPermission
//where AspNetRolePermission.RoleId=AspNetRoles.AspRolesID and
//AspNetRolePermission.PermissionId=AspNetPermission.id and
//AspNetPermission.PermissionDescription='product-create'

        //string product-list=
        //string product-create=
        //string product-edit=
        //string product-delete=

/*
 In order to give role wise access we need to run the query above to get all the roles assigned to the particular permission. And
 then append all the roles to a string variable. Finally put the variable in the authorize attribute as authorize[variables]. write the
 attribute above the webapi method to check access permission of the method.
 */

        // GET api/<controller>
        [HttpGet]
        [Route("products/GetAll")]
        public string Get()
        {
          //custom
            string valString = "";
            //string val="product-create";
            //int pos = Array.IndexOf(CustomPermission.permissionCollection, val);
            //if (pos > -1)
            //{

            //}
            if (CustomPermission.permissionCollection.Contains("product-create"))
            {
                valString="Product List is available";
            }
            else valString="you are not authorized";
            return valString;
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}