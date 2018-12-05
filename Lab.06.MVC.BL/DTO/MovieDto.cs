using System.Collections.Generic;

namespace Lab._06.MVC.BL.DTO
{
    public class MovieDto
    {
        public int MovieID { get; set; }
        public string MovieName { get; set; }
        public string UserMovieNote { get; set; }
        public byte[] MoviePoster { get; set; }
    }
}