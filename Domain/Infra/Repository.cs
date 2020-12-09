using System;
using System.Linq.Expressions;

namespace Domain.Infra
{
    class Repository<T> where T : class
    {
        public void Add(T entity)
        {
            using (var db = new BrasileiraoContext())
            {
                db.Add<T>(entity);
                db.SaveChanges();
            }
        }

        public T Get(Expression<Func<T, bool>> predicate)
        {
            using (var db = new BrasileiraoContext())
            {
                return db.Find<T>(predicate);
            }
        }
    }
}
