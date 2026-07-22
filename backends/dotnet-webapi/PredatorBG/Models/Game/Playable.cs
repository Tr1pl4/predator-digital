using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using WebAPI.PredatorBG.Models.Enums;

namespace WebAPI.PredatorBG.Models
{
    public class Playable : Card
    {
        [Required]
        virtual public PChar Character { get; set; }

        [Required]
        virtual public PClass Class { get; set; }

        [Required]
        virtual public PTeam Team { get; set; }

        [Required]
        public Int32 AttPoint { get; set; }

        [Required]
        public Int32 RecPoint { get; set; }

        public Boolean Activated { get; set; }

        public Int32 CoordinateBy { get; set; }

        public Int32 Price { get; set; }

        [Required]
        virtual public List<PSkill> Skills { get; set; }
    }
}
