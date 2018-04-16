using LooselyCouple.Data.DbOperationInfrastructure;
using LooselyCouple.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LooselyCouple.Data.Repositories
{
    public class RolePermissionRepository : RepositoryBase<RolePermission>
    {
        public RolePermissionRepository(IDbFactory dbFactory)
            : base(dbFactory) { }


        public override void delete(RolePermission entity)
        {
            var rpermission = this.dataContext.rolePermissions.Where(rp => rp.RoleId == entity.RoleId && rp.PermissionId == entity.PermissionId).FirstOrDefault();
            this.dataContext.rolePermissions.Remove(rpermission);
            this.dataContext.SaveChanges();
        }



        //public IEnumerable<RolePermission> getPemissionByRole(AspRoles roles)
        //{
        //    var rpermission = this.dataContext.rolePermissions.Where(rp => rp.RoleId == roles.AspRolesID).ToList();
        //    return rpermission;
        //}

    }

    //public interface IRolePermissionRepository{
    //IEnumerable<RolePermission> getPemissionByRole(AspRoles roles);
    //}


}
