using System;
using System.ComponentModel.DataAnnotations;

namespace WebAPI.PredatorBG.Models.Enums
{
    #region Damage
    public class DSkill
    {
        [Key]
        public Int32 Id { get; set; }

        [Required]
        public DamageSkill Skill { get; set; }
    }
    #endregion

    #region Enemy
    public class ESkill
    {
        [Key]
        public Int32 Id { get; set; }

        [Required]
        public EnemySkill Skill { get; set; }
    }

    public class ETeam
    {
        [Key]
        public Int32 Id { get; set; }

        [Required]
        public EnemyTeam Team { get; set; }
    }
    #endregion

    #region Playable
    public class PSkill
    {
        [Key]
        public Int32 Id { get; set; }

        [Required]
        public PlayableSkill Skill { get; set; }
    }

    public class PChar
    {
        [Key]
        public Int32 Id { get; set; }

        [Required]
        public PlayableCharacter Character { get; set; }
    }

    public class PTeam
    {
        [Key]
        public Int32 Id { get; set; }

        [Required]
        public PlayableTeam Team { get; set; }
    }

    public class PClass
    {
        [Key]
        public Int32 Id { get; set; }

        [Required]
        public PlayableClass Class { get; set; }
    }
    #endregion
}
