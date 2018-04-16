using LooselyCouple.Data.DbOperationInfrastructure;
using LooselyCouple.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LooselyCouple.Data.Repositories
{
    public class UserRoleRepository : RepositoryBase<UserRole>, IRepository<UserRole>
    {
        public UserRoleRepository(IDbFactory dbFactory)
            : base(dbFactory) { }
    }

    //public interface IUserRoleRepository : IRepository<UserRole>
    //{
    //}
}
