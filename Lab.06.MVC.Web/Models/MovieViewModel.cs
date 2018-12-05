using System.ComponentModel;

namespace Lab._06.MVC.Web.Models
{
    public class MovieViewModel
    {
        public int MovieID { get; set; }
        [DisplayName("Movie Name")]
        public string MovieName { get; set; }
        [DisplayName("Movie Note")]
        public string UserMovieNote { get; set; }
        public byte[] MoviePoster { get; set; }
    }
}