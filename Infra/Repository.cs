using System;
using System.Linq;
using Domain.Common;

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
                return db.Find<T>(predicate);
            }
        }

        public T Get(Guid id)
        {
            using (var db = new BrasileiraoContext())
            {
                return db.Set<T>().SingleOrDefault(x => x.Id == id);
            }
        }
    }
}
