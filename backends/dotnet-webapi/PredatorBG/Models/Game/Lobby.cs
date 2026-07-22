using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebAPI.PredatorBG.Models
{
    public class Lobby
    {
        [Key]
        public Int32 Id { get; set; }

        [Required]
        public String Name { get; set; }

        public int PlayersNum { get; set; }

        public virtual PredatorGame LobbyGame { get; set; }

        public Int32 Movie { get; set; }
    }
}
