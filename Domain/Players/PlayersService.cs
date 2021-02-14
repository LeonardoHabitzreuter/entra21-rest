using System;
using Domain.TeamPlayers;

namespace Domain.Players
{
    public class PlayersService : IPlayersService
    {
        private readonly IPlayersRepository _playersRepository;
        private readonly ITeamPlayersRepository _teamPlayersRepository;

        public PlayersService(IPlayersRepository playersRepository, ITeamPlayersRepository teamPlayersRepository)
        {
            _playersRepository = playersRepository;
            _teamPlayersRepository = teamPlayersRepository;
        }

        public CreatedPlayerDTO Create(Guid teamId, string name)
        {
            var player = new Player(name);
            var playerValidation = player.Validate();

            if (playerValidation.isValid)
            {
                var teamPlayer = new TeamPlayer(teamId, player.Id);

                _playersRepository.Add(player);
                _teamPlayersRepository.Add(teamPlayer);

                return new CreatedPlayerDTO(player.Id);
            }

            return new CreatedPlayerDTO(playerValidation.errors);
        }
    }
}
