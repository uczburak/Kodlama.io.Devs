using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Persistence.Repositories
{
    public class EfRepositoryBase<TEntity, TContext> : IRepository<TEntity> 
        where TEntity : class
        where TContext : DbContext
    {
        private readonly DbContext Context;

        public EfRepositoryBase(TContext context)
        {
            Context = context;
        }

        public TEntity Add(TEntity entity)
        {
            Context.Entry(entity).State = EntityState.Added;
            Context.SaveChanges();
            return entity as TEntity;
        }

        public TEntity Update(TEntity entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
            Context.SaveChanges();
            return entity as TEntity;
        }

        public TEntity Delete(TEntity entity)
        {
            Context.Entry(Context).State = EntityState.Deleted;
            Context.SaveChanges();
            return entity as TEntity;
        }

        public TEntity? Get(Expression<Func<TEntity, bool>> predicate)
        {
            return Context.Set<TEntity>().FirstOrDefault(predicate);
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            return filter != null ? Context.Set<TEntity>().Where(filter).ToList() : Context.Set<TEntity>().ToList();
        }

        public IQueryable<TEntity> Query()
        {
            return Context.Set<TEntity>();
        }

        
    }
}
