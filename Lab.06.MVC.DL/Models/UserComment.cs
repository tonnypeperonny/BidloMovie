using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab._06.MVC.DL.Models
{
    public class UserComment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CommentId { get; set; }
        public string Comment { get; set; }
        public int CommentRating { get; set; }
        public int MovieID { get; set; }
        public virtual Movie Movie { get; set; }
        public string UserID { get; set; }
        public string UserName { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}
