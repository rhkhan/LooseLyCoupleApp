using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LooselyCouple.Data.DbOperationInfrastructure
{
    public class UnitOperation:IUnitOperation
    {
        private readonly IDbFactory dbFactory;
        private LooselyCoupleEntities context;

        public UnitOperation(IDbFactory DbFactory)
        {
            dbFactory = DbFactory;
        }


        public LooselyCoupleEntities DbContext
        {
            get { return context?? (context=dbFactory.Init());}
        }

        public void commit()
        {
            //context.Commit();
            DbContext.Commit();
        }
    }
}
