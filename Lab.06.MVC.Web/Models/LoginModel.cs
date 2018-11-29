using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Lab._06.MVC.Web.Models
{
    public class LoginModel
    {
        [DisplayName("Login")]
        [Required]
        public string UserLogin { get; set; }
        [DisplayName("Password")]
        [DataType(DataType.Password)]
        [Required]
        public string UserPasswd { get; set; }
    }
}