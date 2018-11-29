using System.Collections.Generic;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Lab._06.MVC.DL.Models
{
    public class ApplicationUser : IdentityUser
    {
        public virtual ICollection<UserComment> UserComments { get; set; }
    }
}