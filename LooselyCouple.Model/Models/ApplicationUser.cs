using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace LooselyCouple.Model.Models
{
    public class ApplicationUser : IdentityUser
    {

        public virtual Register UserInfo { get; set; }
        public virtual UserRole userroleInfo { get; set; }
        public ApplicationUser()
        {
             UserInfo = new Register();
             userroleInfo = new UserRole();
        }

    }
}
