using System;
using System.ComponentModel.DataAnnotations;

namespace PileOfShame.Models
{
    public class GameModel
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public string Platform { get; set; }
        [Display(Name = "Release Date")]
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }
    }
}// aa