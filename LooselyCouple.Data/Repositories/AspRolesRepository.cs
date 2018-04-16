using LooselyCouple.Data.DbOperationInfrastructure;
using LooselyCouple.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LooselyCouple.Data.Repositories
{
    // This class implements all the methods from the IRepository and IAspRolesRepository
    // Overrides the method in RepositoryBase if any change is needed in the particular virtual method in RepositoryBase

    public class AspRolesRepository : RepositoryBase<AspRoles>, IAspRolesRepository
    {
        public AspRolesRepository(IDbFactory dbFactory)
            : base(dbFactory) { }



        // The current repository have overrided update method with changes if necessary by inheriting the RepositoryBase class that contains all the virtual methods
       // public override void update(AspRoles entity)
       // {
            //entity.Name = "any new name";
            //base.update(entity);
        //}

        // Implemented the extended method from the interface
        public AspRoles GetRolesByName(string rolename)
        {
            var roles = dataContext.aspRoles.Where(c => c.Name == rolename).FirstOrDefault();

            return roles;
        }



        public AspRoles GetRole(int id)
        {
           // throw new NotImplementedException();
            var role = this.dataContext.aspRoles.Where(r => r.AspRolesID == id).FirstOrDefault();
            return role;
          
        }

        public override void delete(AspRoles entity)
        {   
            base.delete(entity);
            this.dataContext.rolePermissions.RemoveRange(this.dataContext.rolePermissions.Where(ur => ur.RoleId == entity.AspRolesID));
            //base.delete(entity);
        }
    }

    // Created an Interface that have an extension method as well as all the methods from the implemented interface
    public interface IAspRolesRepository : IRepository<AspRoles>
    {
        AspRoles GetRolesByName(string rolename);
        AspRoles GetRole(int id);
    }
}

