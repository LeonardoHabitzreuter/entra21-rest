using System;
using System.Linq;
using Domain.Common;
using Microsoft.EntityFrameworkCore;

namespace Infra
{
    public class Repository<T> : IRepository<T> where T : Entity
    {
        public void Add(T entity)
        {
            using (var db = new BrasileiraoContext())
            {
                db.Add<T>(entity);
                db.SaveChanges();
            }
        }

        public T Get(Func<T, bool> predicate)
        {
            using (var db = new BrasileiraoContext())
            {
                return db.Set<T>().SingleOrDefault(predicate);
            }
        }

        public T Get(Guid id)
        {
            return Get(x => x.Id == id);
        }

        public void Remove(T entity)
        {
            using (var db = new BrasileiraoContext())
            {
                db.Entry(entity).State = EntityState.Deleted;
                db.SaveChanges();
            }
        }
    }
}
