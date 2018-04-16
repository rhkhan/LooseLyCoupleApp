using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LooselyCouple.Model.Models
{
   public class Permission
    {
       //public Permission() {
       //    roles = new HashSet<AspRoles>();
       //}

       public int Id { get; set; }
       public string PermissionDescription { get; set; }
       //public virtual ICollection<AspRoles> roles { get; set; }
    }
}
