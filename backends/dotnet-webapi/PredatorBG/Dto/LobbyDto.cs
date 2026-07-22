using WebAPI.PredatorBG.Models;
using System;
using System.Collections.Generic;

namespace WebAPI.PredatorBG.Dto
{
    public class LobbyDto
    {
        public Int32 Id { get; set; }

        public String Name { get; set; }

        public int PlayersNum { get; set; }

        public virtual PredatorGame LobbyGame { get; set; }

        public Int32 Movie { get; set; }

        public static explicit operator Lobby(LobbyDto dto) => new()
        {
            Id = dto.Id,
            Name = dto.Name,
            PlayersNum = dto.PlayersNum,
            LobbyGame = dto.LobbyGame,
            Movie = dto.Movie
        };
        public static explicit operator LobbyDto(Lobby l ) => new()
        {
            Id = l.Id,
            Name = l.Name,
            PlayersNum = l.PlayersNum,
            LobbyGame = l.LobbyGame,
            Movie = l.Movie
        };
    }
}
