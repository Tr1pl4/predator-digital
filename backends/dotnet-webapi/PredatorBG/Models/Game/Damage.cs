using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using WebAPI.PredatorBG.Models.Enums;

namespace WebAPI.PredatorBG.Models
{
    public class Damage : Card
    {
        [Required]
        public Int32 Dmg { get; set; }

        [Required]
        virtual public List<DSkill> Skills { get; set; }
    }
}
