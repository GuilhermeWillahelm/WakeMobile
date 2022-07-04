using System;
using WakeMobile.Models;
using System.Collections.Generic;

namespace WakeMobile.Services
{
    public interface IUserService
    {
        User GetUserById(int id);
        User CreateUser(User user);
        bool LoginUser(UserLogin userLogin);
        User EditUser(int id, User user);
        bool DeleteUser(int id);
        int GetUserId();
        string GetUserName();
    }
}
