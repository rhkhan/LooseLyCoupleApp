using LooselyCouple.Data.DbOperationInfrastructure;
using LooselyCouple.Data.DTO;
using LooselyCouple.Data.Repositories;
using LooselyCouple.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LooslyCouple.Service
{
    public class PermissionService:IPermissionService
    {
        private readonly IPermissionRepository permissionRepository;
        private readonly IUnitOperation unitOperation;

        public PermissionService(IPermissionRepository permissionRepo, IUnitOperation unitOp)
        {
            this.permissionRepository = permissionRepo;
            this.unitOperation = unitOp;
        }

        public void Create(Permission permission)
        {
            permissionRepository.add(permission);
        }

        public void SavePermission()
        {
            unitOperation.commit();
        }

        public IEnumerable<Permission> GetPermissions()
        {
            var permissions = permissionRepository.GetAll();
            return permissions;
        }




        public Permission GetPermissionById(int id)
        {
            var p = permissionRepository.GetPermissionById(id);
            return p;
        }


        public void UpdatePermission(Permission p)
        {
              permissionRepository.update(p);
        }


        public void DeletePermission(Permission p)
        {
            //throw new NotImplementedException();
            permissionRepository.delete(p);
        }


        //public RolePermission GetPermissionStat(int id, int id2)
        //{
        //    //throw new NotImplementedException();
        //    return permissionRepository.GetPermissionStat(id, id2);
        //}


        public IEnumerable<PermissionWithStateByRoleDTO> GetPermissionWithStateByRole(int RoleId)
        {
            return permissionRepository.GetPermissionWithStateByRole(RoleId);
        }
    }

    public interface IPermissionService
    {
        void Create(Permission permission);
        void SavePermission();
        IEnumerable<Permission> GetPermissions();
        Permission GetPermissionById(int id);
        void UpdatePermission(Permission p);
        void DeletePermission(Permission p);
        IEnumerable<PermissionWithStateByRoleDTO> GetPermissionWithStateByRole(int RoleId);
    }
}
