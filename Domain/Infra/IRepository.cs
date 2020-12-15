using System;

namespace Domain.Infra
{
    public interface IRepository<T> where T : class
    {
        void Add(T entity);

        T Get(Func<T, bool> predicate);
    }
}
