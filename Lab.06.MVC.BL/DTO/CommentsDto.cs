namespace Lab._06.MVC.BL.DTO
{
    public class CommentsDto
    {
        public int CommentId { get; set; }
        public string Comment { get; set; }
        public int MovieId { get; set; }
        public string UserName { get; set; }
        public string Id { get; set; }
        public int CommentRating { get; set; }
    }
}