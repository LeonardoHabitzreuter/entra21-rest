using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Domain.Common;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositories
{
    public class Repository<T> : IRepository<T> where T : Entity
    {
        protected readonly BrasileiraoContext brasileiraoContext;

        public Repository(BrasileiraoContext brasileiraoContext)
        {
            this.brasileiraoContext = brasileiraoContext;
        }

        public void Add(T entity)
        {
            brasileiraoContext.Add<T>(entity);
            brasileiraoContext.SaveChanges();
        }

        public IList<T> GetAllIncluding<TProperty>(Expression<Func<T, TProperty>> includes)
        {
            return brasileiraoContext.Set<T>().Include(includes).ToList();
        }

        public T Get(Func<T, bool> predicate)
        {
            return brasileiraoContext.Set<T>().SingleOrDefault(predicate);
        }

        public T Get(Guid id)
        {
            return Get(x => x.Id == id);
        }
    }
}
