using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Lab._06.MVC.Web.Models
{
    public class RegisterModel
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        [DisplayName("Login")]
        public string UserLogin { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [MinLength(6)]
        [DisplayName("Password")]
        public string UserPasswd { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Compare("UserPasswd")]
        [MinLength(6)]
        [DisplayName("Confirm the password")]
        public string ConfirmUserPasswd { get; set; }
        [DisplayName("User Name")]
        public string UserName { get; set; }
    }
}