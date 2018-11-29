using System.Security.Claims;
using Lab._06.MVC.BL.DTO;

namespace Lab._06.MVC.BL.UserService
{
    public interface IUserService
    {
        void Create(UserDto userdto);
        ClaimsIdentity Authenticate(UserDto userDto);
    }
}