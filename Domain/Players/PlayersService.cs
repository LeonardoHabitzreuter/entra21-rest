﻿using System;

namespace Domain.Players
{
    public class PlayersService
    {
        public CreatedPlayerDTO Create(Guid teamId, string name)
        {
            var player = new Player(teamId, name);
            var playerValidation = player.Validate();

            if (playerValidation.isValid)
            {
                PlayersRepository.Add(player);
                return new CreatedPlayerDTO(player.Id);
            }

            return new CreatedPlayerDTO(playerValidation.errors);
        }

        public Guid? Remove(Guid id)
        {
            return PlayersRepository.Remove(id);
        }
    }
}
