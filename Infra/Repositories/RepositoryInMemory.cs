using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Domain.Common;

namespace Infra.Repositories
{
    public class RepositoryInMemory<T> : IRepository<T> where T : Entity
    {
        private List<T> _entities = new List<T>();
        public IReadOnlyCollection<T> Entities => _entities;

        public void Add(T entity)
        {
            _entities.Add(entity);
        }

        public T Get(Func<T, bool> predicate)
        {
            return _entities.FirstOrDefault(predicate);
        }

        public T Get(Guid id)
        {
            return _entities.FirstOrDefault(x => x.Id == id);
        }

        public IList<T> GetAllIncluding<TProperty>(Expression<Func<T, TProperty>> includes)
        {
            return _entities;
        }

        public IList<T> GetAll()
        {
            return _entities;
        }

        public void Remove(T entity)
        {
            _entities.Remove(entity);
        }
    }
}
