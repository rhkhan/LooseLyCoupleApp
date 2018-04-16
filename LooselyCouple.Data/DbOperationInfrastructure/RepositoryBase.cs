using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LooselyCouple.Data.DbOperationInfrastructure
{
    public abstract class RepositoryBase<T> where T : class
    {
        private LooselyCoupleEntities context;
        private readonly IDbSet<T> dbSet;

        protected IDbFactory DbFactory
        {
            get;
            private set;
        }

        protected LooselyCoupleEntities dataContext
        {
            get { return context ?? (context = DbFactory.Init()); }
        }

        protected RepositoryBase(IDbFactory dbFactory)
        {
            DbFactory = dbFactory;
            dbSet = dataContext.Set<T>();
        }

        #region Implementation
        public virtual void add(T entity)
        {
            dbSet.Add(entity);
        }

        public virtual void update(T entity)
        {
            dbSet.Attach(entity);
            context.Entry(entity).State = EntityState.Modified;
        }

        public virtual void delete(T entity)
        {
            dbSet.Remove(entity);
        }

        public virtual IEnumerable<T> GetAll()
        {
            return dbSet.ToList();
        }

        #endregion

    }

}
