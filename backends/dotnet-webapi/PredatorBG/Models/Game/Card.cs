using System;
using System.ComponentModel.DataAnnotations;

namespace WebAPI.PredatorBG.Models
{
    public class Card
    {
        [Key]
        public Int32 Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Imagepath { get; set; }
    }
}
