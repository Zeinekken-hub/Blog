using BlogMvcApp.BLL.Infrastructure;
using BlogMvcApp.BLL.Interfaces;
using BlogMvcApp.BLL.Models;
using BlogMvcApp.DLL.Entities;
using BlogMvcApp.DLL.Interfaces;
using Microsoft.AspNet.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace BlogMvcApp.BLL.Services
{
    public class UserService : IUserService
    {
        public IUnitOfWork Database { get; }
        public UserService(IUnitOfWork unitOfWork)
        {
            Database = unitOfWork;
        }

        public OperationDetails Create(UserDto userDto)
        {
            var user = Database.UserManager.FindByEmail(userDto.Email);
            if (user != null) return new OperationDetails(false, "User with the same login exists", "Email");

            user = new BlogUser { Email = userDto.Email, UserName = userDto.Email };
            var result = Database.UserManager.Create(user, userDto.Password);

            if (result.Errors.Any()) return new OperationDetails(false, result.Errors.FirstOrDefault(), "");

            Database.UserManager.AddToRole(user.Id, userDto.Role);

            Database.Save();
            return new OperationDetails(true, "Registration succed", "");

        }

        public ClaimsIdentity Authenticate(UserDto userDto)
        {
            var user = Database.UserManager.Find(userDto.Email, userDto.Password);
            if (user == null) return null;

            return Database.UserManager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);
        }

        public void SetInitialData(UserDto adminDto, List<string> roles)
        {
            foreach (var roleName in roles)
            {
                var role = Database.RoleManager.FindByName(roleName);

                if (role != null) continue;

                role = new ApplicationRole { Name = roleName };
                Database.RoleManager.Create(role);
            }
            Create(adminDto);
        }

        public UserDto GetUserByUserName(string username)
        {
            var user = Database.UserManager.Users.FirstOrDefault(u => u.UserName == username);
            if (user == null) return null;
            return new UserDto
            {
                Email = user.Email,
                Password = user.PasswordHash,
                UserName = user.UserName
            };
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
