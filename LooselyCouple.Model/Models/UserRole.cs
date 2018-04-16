using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LooselyCouple.Model.Models
{
    public class UserRole //: IdentityUserRole<string>
    {
        public string userId { get; set; }
        public int roleId { get; set; }
    }

    public class IdentityUserRole<TKey>
    {
        /// <summary>
        ///     UserId for the user that is in the role
        /// </summary>
        public virtual TKey UserId { get; set; }

        /// <summary>
        ///     RoleId for the role
        /// </summary>
        public virtual TKey RoleId { get; set; }
    }
}
