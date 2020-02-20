using BlogMvcApp.BLL.Infrastructure;
using BlogMvcApp.BLL.Models;
using System;
using System.Collections.Generic;
using System.Security.Claims;

namespace BlogMvcApp.BLL.Interfaces
{
    public interface IUserService : IDisposable
    {
        OperationDetails Create(UserDto userDto);
        ClaimsIdentity Authenticate(UserDto userDto);
        void SetInitialData(UserDto adminDto, List<string> roles);
        UserDto GetUserByUserName(string username);
    }
}
