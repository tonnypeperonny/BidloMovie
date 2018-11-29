using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Lab._06.MVC.Web.Models
{
    public class CommentsModel
    {
        [Required(ErrorMessage = "Comment is empty!")]
        [DisplayName("Comment")]
        [StringLength(255, ErrorMessage = "Comment must be between 1 and 255 characters", MinimumLength = 1)]
        public string UserComment { get; set; }
        public int MovieAddCommentsId { get; set; }
    }
}