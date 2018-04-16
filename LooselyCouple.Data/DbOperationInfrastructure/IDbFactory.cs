using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LooselyCouple.Data.DbOperationInfrastructure
{
    public interface IDbFactory:IDisposable
    {
        LooselyCoupleEntities Init();
    }
}
