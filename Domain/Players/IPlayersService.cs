using System;

namespace Domain.Players
{
    public interface IPlayersService
    {
        CreatedPlayerDTO Create(Guid teamId, string name);
    }
}
