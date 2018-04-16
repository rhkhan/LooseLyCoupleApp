using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LooselyCouple.Data.DTO
{
    public class PermissionWithStateByRoleDTO
    {
        public int PermissionId { get; set; }
        public string PermissionDescription { get; set; }
        public int Status { get; set; }
        public string UserName { get; set; }
    }
}
