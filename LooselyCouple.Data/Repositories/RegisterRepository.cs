using LooselyCouple.Data.DbOperationInfrastructure;
using LooselyCouple.Data.DTO;
using LooselyCouple.Model.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LooselyCouple.Data.Repositories
{
    public class RegisterRepository : RepositoryBase<Register> , IRegisterRepository
    {
        //private UserManager<ApplicationUser> _securityManager;

        public string Username { get; set; }
        private List<int> roles = new List<int>();
        private List<Permission> permissions = new List<Permission>();

        public RegisterRepository(IDbFactory dbFactory)
            : base(dbFactory) {

        }

        public Register GetUser(string id)
        {
            var user = this.dataContext.users.Where(r => r.Id == id).FirstOrDefault();
            return user;
        }


        public IEnumerable<AspRolesDTO> GetUserRoles(string id)
        {
      

            var users = (from r in this.dataContext.aspRoles
                         join ur in this.dataContext.UserRoles on r.AspRolesID equals ur.roleId
                         where ur.userId == id
                         select new AspRolesDTO
                         {
                             Id=r.AspRolesID,
                             Name=r.Name
                         }).ToList();

                         //select new  //###### if IEnumerable<Object> is needed to return
                         //{
                         //    u.Id,
                         //    u.Firstname,
                         //    r.Name
                         //}).ToList();

            return users;
        }

        public void updateUser(RegisterViewModel model)
        {
            try
            {
                var user = new Register
                {
                    Id=model.Id,
                    Firstname=model.Firstname,
                    Lastname=model.Lastname
                };

                this.dataContext.users.Attach(user);
                this.dataContext.Entry(user).State = System.Data.Entity.EntityState.Modified;

                this.dataContext.UserRoles.RemoveRange(this.dataContext.UserRoles.Where(ur => ur.userId == model.Id));
                for (int i = 0; i < model.selectedRole.Length; i++)
                {
                    var temp = Convert.ToInt32(model.selectedRole[i]);
                    var role = this.dataContext.aspRoles.Where(r => r.AspRolesID == temp).FirstOrDefault();
                    var userrole = new UserRole();
                    userrole.userId = model.Id;
                    userrole.roleId = role.AspRolesID;

                    this.dataContext.UserRoles.Add(userrole);
                }
                this.dataContext.SaveChanges();
            }
            catch (Exception ex) { ex.ToString(); }
        }


        public async Task RegisterUser(RegisterViewModel model)
        {
            try
            {
                var user = new Register
                {
                    Id = System.Guid.NewGuid().ToString(),
                    Firstname = model.Firstname,
                    Lastname = model.Lastname,
                    Username=model.Username,
                    PasswordHash = model.PasswordHash,
                    Email = model.Email
                };
                
                this.dataContext.users.Add(user);

                for (int i = 0; i < model.selectedRole.Length; i++)
                {
                    var temp = model.selectedRole[i];
                    var role = this.dataContext.aspRoles.Where(r => r.Name == temp).FirstOrDefault();
                    var userrole = new UserRole(); // To avoid exception to while assigning different value to same object shows due to safety in EF
                    userrole.userId = user.Id;
                    userrole.roleId = role.AspRolesID;
                    
                    this.dataContext.UserRoles.Add(userrole);
                }
                this.dataContext.SaveChanges();
            }
            catch (Exception ex)
            {
                ex.ToString();
            }

            /*
            var appUser = new ApplicationUser();
            appUser.UserInfo = user;
            appUser.userroleInfo = userrole;

            try
            {

                UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new LooselyCoupleEntities()));
                var result = await UserManager.CreateAsync(appUser, model.Password);

                await this.UserManager.AddToRoleAsync(user.Id, model.selectedRole); // added role to user
            }
            catch (Exception ex)
            {
                ex.ToString();
            }


            await this.SecurityManager.AddToRoleAsync(user.Id, model.Name); // added role to user
            if (result.Succeeded)
            {
                await _loginManager.SignInAsync(user, isPersistent: false);
                return RedirectToAction(nameof(HomeController.Index), "Home");
            }
             * 
             */
        }




        public List<Permission> GetDataBaseUserRolesPermissions(string Username)
        {
            //throw new NotImplementedException();
            using (LooselyCoupleEntities _data = new LooselyCoupleEntities())
            {
                Register _user = _data.users.Where(u => u.Username == this.Username).FirstOrDefault();

                if (_user != null)
                {
                    //this.user_id = _user.Id;
                    var roles = _data.UserRoles.Where(ur => ur.userId == _user.Id).ToList();

                    for (int i = 0; i < roles.Count; i++)
                    {
                        var temp = roles[i].roleId;
                        var _rolepermission = _data.rolePermissions.Where(p => p.RoleId == temp).ToList();
                        for (int j = 0; j < _rolepermission.Count; j++)
                        {
                            var tempPermission = _rolepermission[j].PermissionId;
                            var permissionData = _data.permissions.Where(pd => pd.Id == tempPermission).ToList();
                            for (int k = 0; k < permissionData.Count; k++)
                                permissions.Add(new Permission { Id = permissionData[k].Id, PermissionDescription = permissionData[k].PermissionDescription });
                        }
                    }
                }

                return permissions;
            }
        }
    }

    public interface IRegisterRepository : IRepository<Register>
    {
        Register GetUser(string id);
        Task RegisterUser(RegisterViewModel model);
        void updateUser(RegisterViewModel model);
        IEnumerable<AspRolesDTO> GetUserRoles(string id);
        List<Permission> GetDataBaseUserRolesPermissions(string Username);
    }
}
