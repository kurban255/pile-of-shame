using System;
using System.ComponentModel.DataAnnotations;

namespace PileOfShame.Models
{
    public class GameModel
    {
        public int ID { get; set; }
        [Required]
        public string Title { get; set; }
        public string Genre { get; set; }
        public string Platform { get; set; }
        [Display(Name = "Release Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        public DateTime ReleaseDate { get; set; }
    }
}