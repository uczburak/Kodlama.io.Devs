using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Persistence.Repositories
{
    public interface IRepository<T> : IQuery<T> where T : class
    {
        T Add(T entity);
        T Update(T entity);
        T Delete(T entity);
        T Get(Expression<Func<T, bool>> predicate);
        List<T> GetAll(Expression<Func<T, bool>> filter = null);
    }
}
