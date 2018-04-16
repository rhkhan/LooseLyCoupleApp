using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LooselyCouple.Data.DbOperationInfrastructure
{
    public interface IRepository<T> where T : class
    {
        void add(T entity);
        void update(T entity);
        void delete(T entity);
        IEnumerable<T> GetAll();
    }
}
