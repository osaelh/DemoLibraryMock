using DemoLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoLibrary.Logic
{
   public interface IUserProcessor
    {
        List<UserModel> LoadUsers();

        void SaveUser(UserModel user);

        void UpdateUser(UserModel user);

        UserModel CreateUser(string UserName, string Email, string Password, int Access);
    }
}
