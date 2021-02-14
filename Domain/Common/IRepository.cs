using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Domain.Common
{
    public interface IRepository<T> where T : Entity
    {
        void Add(T entity);
        IList<T> GetAllIncluding<TProperty>(Expression<Func<T, TProperty>> includes);
        T Get(Func<T, bool> predicate);
        T Get(Guid id);
        void Remove(T entity);
    }
}
