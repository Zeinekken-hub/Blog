using BlogMvcApp.DLL.Entities;
using System;

namespace BlogMvcApp.DLL.Interfaces
{
    public interface IClientManager : IDisposable
    {
        void Create(ClientProfile item);
    }
}
