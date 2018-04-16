using LooselyCouple.Data.DbOperationInfrastructure;
using LooselyCouple.Data.DTO;
using LooselyCouple.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LooselyCouple.Data.Repositories
{
    public class PermissionRepository:RepositoryBase<Permission>,IPermissionRepository
    {
        public PermissionRepository(IDbFactory dbFactory)
            : base(dbFactory) { }

        public Permission GetPermission(int id)
        {
            var permission = this.dataContext.permissions.Where(p => p.Id == id).FirstOrDefault();
            return permission;
        }


        public Permission GetPermissionById(int id)
        {
            var p = this.dataContext.permissions.Where(r => r.Id == id).FirstOrDefault();
            return p;
        }


        /*
            select AspNetPermission.Id, AspNetPermission.PermissionDescription, CASE WHEN AspNetRolePermission.RoleId Is NOT NULL THEN 1 ELSE 0 END Stat
            from AspNetPermission
            LEFT OUTER JOIN AspNetRolePermission on AspNetRolePermission.PermissionId=AspNetPermission.Id AND AspNetRolePermission.RoleId=3
        */

        public IEnumerable<PermissionWithStateByRoleDTO> GetPermissionWithStateByRole(int RoleId)
        {
            var query= (from p in this.dataContext.permissions
                       //join rp in this.dataContext.rolePermissions on p.Id equals rp.PermissionId into rps
                       from rp in this.dataContext.rolePermissions
                       .Where(x=>x.PermissionId==p.Id)
                       .Where(x=>x.RoleId==RoleId)
                       .DefaultIfEmpty()
                       //from PRM in rps.DefaultIfEmpty()
                       select new PermissionWithStateByRoleDTO{
                           PermissionId=p.Id,
                           PermissionDescription=p.PermissionDescription,
                           Status=rp.RoleId!=null?1:0
                        }
                       ).ToList();

            return query;
        }
    }

    public interface IPermissionRepository : IRepository<Permission>
    {
        Permission GetPermission(int id);
        Permission GetPermissionById(int id);
        IEnumerable<PermissionWithStateByRoleDTO> GetPermissionWithStateByRole(int RoleId);
    }
}
