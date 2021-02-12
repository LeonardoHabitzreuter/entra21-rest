﻿
using System;
using Domain.Common;

namespace Domain.Teams
{
    public class TeamsRepository : ITeamsRepository
    {
        private readonly IRepository<Team> _repository;

        public TeamsRepository(IRepository<Team> repository)
        {
            _repository = repository;
        }
        public void Add(Team team)
        {
            _repository.Add(team);
        }

        public Team Get(Func<Team, bool> predicate)
        {
            return _repository.Get(predicate);
        }

        public Team Get(Guid id)
        {
            return _repository.Get(id);
        }

        public void Remove(Team entity)
        {
            _repository.Remove(entity);
        }
    }
}
