using System;

namespace Domain.Infra
{
    public class Repository<T> : IRepository<T> where T : class
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
    }
}
