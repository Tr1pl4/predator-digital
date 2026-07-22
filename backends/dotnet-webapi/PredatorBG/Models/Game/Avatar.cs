using System;
using System.ComponentModel.DataAnnotations;

namespace WebAPI.PredatorBG.Models
{
    public class Avatar
    {
        [Key]
        public Int32 Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int Team { get; set; }

        [Required]
        public Int32 Health { get; set; }

        [Required]
        public Int32 Armor { get; set; }

        [Required]
        public string Imagepath { get; set; }

    }
}
