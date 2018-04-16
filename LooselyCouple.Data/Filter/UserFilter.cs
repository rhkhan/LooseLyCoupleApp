using LooselyCouple.Data.DbOperationInfrastructure;
using LooselyCouple.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LooselyCouple.Data.Filter
{
    public class UserFilter:IUserFilter
    {
        public string user_id { get; set; }
       // public string Username { get; set; }
        private List<int> roles = new List<int>();
        private List<Permission> permissions = new List<Permission>();

        //public UserFilter(string _Username)
        //{
        //    this.Username = _Username;
        //    //GetDataBaseUserRolesPermissions();
        //}

        public List<Permission> GetDataBaseUserRolesPermissions(string Username,string password)
        {
            permissions = new List<Permission>();

            using (LooselyCoupleEntities _data = new LooselyCoupleEntities()) 
            {
                Register _user = _data.users.Where(u => u.Username == Username && u.PasswordHash==password).FirstOrDefault();

                if (_user != null)
                {
                    this.user_id = _user.Id;
                    var roles=_data.UserRoles.Where(ur => ur.userId == this.user_id).ToList();

                    for (int i = 0; i < roles.Count; i++)
                    {
                        var temp=roles[i].roleId;
                        var _rolepermission = _data.rolePermissions.Where(p => p.RoleId == temp).ToList();
                        for (int j = 0; j < _rolepermission.Count; j++) {
                            var tempPermission = _rolepermission[j].PermissionId;
                            var permissionData = _data.permissions.Where(pd => pd.Id == tempPermission).ToList();
                            for (int k = 0; k < permissionData.Count;k++ )
                                permissions.Add(new Permission { Id = permissionData[k].Id, PermissionDescription = permissionData[k].PermissionDescription });
                        }
                    }
                }

                return permissions;
            }

        }

        public bool IsUser(string name)
        {
            using (LooselyCoupleEntities _data = new LooselyCoupleEntities())
            {
                //List<AspRoles> roles = new List<AspRoles>();
                var _users = _data.users.Where(p => p.Username == name).ToList();
                //var _users = _data.users.Where(u => u.Username == name).FirstOrDefault();
                return (_users.Count > 0);
            }
        }



    }

    public interface IUserFilter {
        List<Permission> GetDataBaseUserRolesPermissions(string Username,string password);
        bool IsUser(string name);
    }

}
