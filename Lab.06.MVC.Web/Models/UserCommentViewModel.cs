namespace Lab._06.MVC.Web.Models
{
    public class UserCommentViewModel
    {
        public int CommentID { get; set; }
        public string UserComment { get; set; }
        public int MovieID { get; set; }
        public string UserID { get; set; }
        public string UserName { get; set; }
        public int CommentRating { get; set; }
    }
}