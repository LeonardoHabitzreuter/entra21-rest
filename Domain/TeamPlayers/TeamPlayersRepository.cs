
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Domain.Common;

namespace Domain.TeamPlayers
{
    public class TeamPlayersRepository : ITeamPlayersRepository
    {
        private readonly IRepository<TeamPlayer> _repository;

        public TeamPlayersRepository(IRepository<TeamPlayer> repository)
        {
            _repository = repository;
        }
        public void Add(TeamPlayer teamPlayer)
        {
            _repository.Add(teamPlayer);
        }

        public TeamPlayer Get(Func<TeamPlayer, bool> predicate)
        {
            return _repository.Get(predicate);
        }

        public TeamPlayer Get(Guid id)
        {
            return _repository.Get(id);
        }

        public IList<TeamPlayer> GetAllIncluding<TProperty>(Expression<Func<TeamPlayer, TProperty>> includes)
        {
            return _repository.GetAllIncluding(includes);
        }
    }
}
