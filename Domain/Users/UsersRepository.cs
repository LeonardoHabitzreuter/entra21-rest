using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Domain.Common;

namespace Domain.Users
{
    public class UsersRepository : IUsersRepository
    {
        private readonly IRepository<User> _repository;

        public UsersRepository(IRepository<User> repository)
        {
            _repository = repository;
        }
        public void Add(User user)
        {
            _repository.Add(user);
        }

        public User Get(Func<User, bool> predicate)
        {
            return _repository.Get(predicate);
        }

        public User Get(Guid id)
        {
            return _repository.Get(id);
        }

        public IList<User> GetAllIncluding<TProperty>(Expression<Func<User, TProperty>> includes)
        {
            return _repository.GetAllIncluding(includes);
        }
        
        public void Remove(User entity)
        {
            _repository.Remove(entity);
        }
    }
}
