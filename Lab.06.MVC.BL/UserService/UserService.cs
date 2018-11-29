using System;
using System.Security.Claims;
using Lab._06.MVC.BL.DTO;
using Lab._06.MVC.DL.Models;
using Lab._06.MVC.DL.Uow;
using Microsoft.AspNet.Identity;

namespace Lab._06.MVC.BL.UserService
{
    public class UserService : IUserService
    {
        private readonly IUow uow;

        public UserService(IUow uow)
        {
            this.uow = uow;
        }

        public void Create(UserDto userdto)
        {
            ApplicationUser currentuser;
            if (uow.UserManager.FindByEmail(userdto.UserLogin) == null)
            {
                currentuser = new ApplicationUser
                {
                    Email = userdto.UserLogin,
                    UserName = userdto.UserName,
                };
            }
            else
            {
                throw new InvalidOperationException("User with this login is exist!");
            }
            uow.UserManager.Create(currentuser, userdto.UserPasswd);
            uow.UserManager.AddToRole(currentuser.Id, userdto.Role);
            uow.Save();
        }

        public ClaimsIdentity Authenticate(UserDto userDto)
        {
            ClaimsIdentity claim = null;
            var user = uow.UserManager.FindByEmail(userDto.UserLogin);
            if (user != null && uow.UserManager.CheckPassword(user, userDto.UserPasswd))
            {
                claim = uow.UserManager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);
            }
            return claim;
        }
    }
}