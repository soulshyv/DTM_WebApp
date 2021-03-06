﻿using System.Threading.Tasks;

namespace UserManager.Contracts
{
    public interface IUserManager
    {
        string UserName { get;}
        string Password { get;}
        bool IsConnected { get;}

        Task<int> Connect(string username, string password);
        bool Connected();
    }
}