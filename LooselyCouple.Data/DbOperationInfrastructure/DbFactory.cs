using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LooselyCouple.Data.DbOperationInfrastructure
{
    public class DbFactory:Disposable, IDbFactory
    {
        LooselyCoupleEntities dbContext;

        public LooselyCoupleEntities Init()
        {
            return dbContext ?? (dbContext = new LooselyCoupleEntities());
        }


        protected override void DisposeCore()
        {
            if (dbContext != null)
                dbContext.Dispose();
        }

    }
}
