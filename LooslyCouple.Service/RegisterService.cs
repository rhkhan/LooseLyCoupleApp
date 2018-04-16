using LooselyCouple.Data.DbOperationInfrastructure;
using LooselyCouple.Data.DTO;
using LooselyCouple.Data.Filter;
using LooselyCouple.Data.Repositories;
using LooselyCouple.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LooslyCouple.Service
{
    public class RegisterService : IRegisterService//,IUserFilter
    {
        private readonly IRegisterRepository userRepository;
        private readonly IUnitOperation unitOperation;
        //private readonly IUserFilter userFilter;

        public RegisterService(IRegisterRepository userRepo, IUnitOperation unitOp)
        {
            this.userRepository = userRepo;
            //this.userRoleRepository = userRoleRepo;
            this.unitOperation = unitOp;
            //this.userFilter = uf;
        }

        public void CreateUser(RegisterViewModel user)
        {
            userRepository.RegisterUser(user);
            //userRoleRepository.add(userRole);
        }

        public void SaveUser()
        {
            unitOperation.commit();
        }

        public IEnumerable<Register> GetUsers()
        {
            var users = userRepository.GetAll();
            return users;
        }

        public IEnumerable<AspRolesDTO> GetUserRoles(string id)
        {
            var users = userRepository.GetUserRoles(id);
            return users;
        }

        public Register GetUser(string id)
        {
            var user = userRepository.GetUser(id);
            return user;
        }

        public void UpdateUser(RegisterViewModel user)
        {
            userRepository.updateUser(user);
        }

        //public void UpdateUserRole(Register model)
        //{
        //    userRepository.updateUserRoles(model);
        //}

        public void DeleteRole(Register user)
        {
            userRepository.delete(user);
        }


        //public List<Permission> GetPermissionsByUser(string username)
        //{
        //return userRepository.GetDataBaseUserRolesPermissions(username);
        //}

        //public List<Permission> GetDataBaseUserRolesPermissions(string Username)
        //{
        //    return userFilter.GetDataBaseUserRolesPermissions(Username);
        //}
    }

    public interface IRegisterService
    {
        void CreateUser(RegisterViewModel user); //UserRole userRole
        void SaveUser();
        IEnumerable<Register> GetUsers();
        IEnumerable<AspRolesDTO> GetUserRoles(string id);
        Register GetUser(string id);
        void UpdateUser(RegisterViewModel user);
        void DeleteRole(Register user);
        //List<Permission> GetPermissionsByUser(string username);
    }
}
