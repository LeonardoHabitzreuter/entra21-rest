using System;
using System.Collections.Generic;
using System.Linq;

namespace Domain.Players
{
    static class PlayersRepository
    {
        private static List<Player> _players = new List<Player>();
        public static IReadOnlyCollection<Player> Players => _players;

        public static void Add(Player player)
        {
            _players.Add(player);
        }

        public static Guid? Remove(Guid id)
        {
            var player = _players.FirstOrDefault(x => x.Id == id);
            if (player == null){
                return null;
            }

            _players.Remove(player);
            return id;
        }
    }
}
