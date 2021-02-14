
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Domain.Common;

namespace Domain.Players
{
    public class PlayersRepository : IPlayersRepository
    {
        private readonly IRepository<Player> _repository;

        public PlayersRepository(IRepository<Player> repository)
        {
            _repository = repository;
        }
        public void Add(Player player)
        {
            _repository.Add(player);
        }

        public Player Get(Func<Player, bool> predicate)
        {
            return _repository.Get(predicate);
        }

        public Player Get(Guid id)
        {
            return _repository.Get(id);
        }

        public IList<Player> GetAllIncluding<TProperty>(Expression<Func<Player, TProperty>> includes)
        {
            return _repository.GetAllIncluding(includes);
        }
    }
}
