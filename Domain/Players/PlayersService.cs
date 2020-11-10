﻿namespace Domain.Players
{
    public class PlayersService
    {
        public CreatedPlayerDTO Create(string name)
        {
            var player = new Player(name);
            var playerValidation = player.Validate();

            if (playerValidation.isValid)
            {
                PlayersRepository.Add(player);
                return new CreatedPlayerDTO(player.Id);
            }

            return new CreatedPlayerDTO(playerValidation.errors);
        }
    }
}
