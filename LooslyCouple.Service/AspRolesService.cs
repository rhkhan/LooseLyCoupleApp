using LooselyCouple.Data.DbOperationInfrastructure;
using LooselyCouple.Data.Repositories;
using LooselyCouple.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LooslyCouple.Service
{
    public class AspRolesService:IAspRolesService
    {
        private readonly IAspRolesRepository aspRolesRepository;
        private readonly IUnitOperation unitOperation;
        private readonly RolePermissionRepository rolePermissionRepository;

        public AspRolesService(IAspRolesRepository aspRoleRepo, IUnitOperation unitOp, RolePermissionRepository rpRepo) {
            this.aspRolesRepository = aspRoleRepo;
            this.unitOperation = unitOp;
            this.rolePermissionRepository = rpRepo;
        }

        public void CreateRoles(AspRoles aspRoles)
        {
            //throw new NotImplementedException();
            aspRolesRepository.add(aspRoles);
        }

        public void Save()
        {
            //throw new NotImplementedException();
            unitOperation.commit();
        }

        public IEnumerable<AspRoles> GetRoles()
        {
            var roles = aspRolesRepository.GetAll();
            return roles;
        }



        public AspRoles GetRole(int id)
        {
            var role = aspRolesRepository.GetRole(id);
            return role;
            //throw new NotImplementedException();

        }


        public void UpdateRoles(AspRoles role)
        {
            aspRolesRepository.update(role);
            //throw new NotImplementedException();
        }


        public void DeleteRole(AspRoles role)
        {
            aspRolesRepository.delete(role);
            //throw new NotImplementedException();
        }


        public void addPermissionToRole(RolePermission pr)
        {
            rolePermissionRepository.add(pr);
        }


        public void removePermissionFromRole(RolePermission pr)
        {
            rolePermissionRepository.delete(pr);
        }


        //public void DeleteRoleAndPermission(AspRoles role)
        //{
        //    var r = aspRolesRepository.GetRole(role.AspRolesID);
        //    //var rolePermissionData=rolePermissionRepository.get
        //    var rolePermissionEntity = rolePermissionRepository.getPemissionByRole(role.AspRolesID);
        //    //rolePermissionRepository.delete(rolePermissionEntity);
        //    //throw new NotImplementedException();
        //}
    }


    public interface IAspRolesService
    {
        void CreateRoles(AspRoles aspRoles);
        void Save();
        IEnumerable<AspRoles> GetRoles();
        AspRoles GetRole(int id);
        void UpdateRoles(AspRoles role);
        void DeleteRole(AspRoles role);
        void addPermissionToRole(RolePermission pr);
        void removePermissionFromRole(RolePermission pr);
        //void DeleteRoleAndPermission(AspRoles role);
    }

}
