
using System;

namespace Domain.Common
{
    public abstract class Entity
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Entity() {}
        public Entity(Guid id)
        {
            Id = id;
        }
    }
}