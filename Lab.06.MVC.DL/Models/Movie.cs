using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab._06.MVC.DL.Models
{
    public class Movie
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MovieID { get; set; }
        public string MovieName { get; set; }
        public string UserMovieNote { get; set; }
        public byte[] MoviePoster { get; set; }
        public virtual ICollection<UserComment> MovieComments { get; set; }
    }
}