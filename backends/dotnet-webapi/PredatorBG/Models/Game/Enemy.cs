using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using WebAPI.PredatorBG.Models.Enums;

namespace WebAPI.PredatorBG.Models
{
    public class Enemy : Card
    {
        [Required]
        public Int32 Health { get; set; }

        virtual public ETeam Team { get; set; }

        [Required]
        virtual public List<ESkill> Skills { get; set; }

        public bool FaceDown { get; set; }
    }
}
