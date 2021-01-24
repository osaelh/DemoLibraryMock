using DemoLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;
using DemoLibrary.Utilities;
using Dapper;
using System.Data.SqlClient;

namespace DemoLibrary.Logic
{
    public class UserProcessor : IUserProcessor
    {
        DataAccess _database = new DataAccess();
        public UserProcessor(DataAccess database)
        {
            _database = database;
        }
        public UserProcessor()
        {

        }
        public List<UserModel> LoadUsers()
        {
            /*string sql = "select * from Users";*/

            var output = _database.LoadData<UserModel>("select UserName, Email, Password, IsStudent from Users");

            return output;
        }

        public void SaveUser(UserModel user)
        {
            string sql = "insert into Users (UserName,Email,Password,Access) " +
                "values (@UserName, @Email, @Password, @Access)";

           /* sql = sql.Replace("@UserId", $"'{ user.UserId }'");*/
            sql = sql.Replace("@UserName", $"'{ user.UserName }'");
            sql = sql.Replace("@Email", $"'{ user.Email }'");
            sql = sql.Replace("@Password", $"'{ user.Password }'");
            sql = sql.Replace("@Access", $"{ user.Access }");
            /*sql = sql.Replace("@IsStudent", $"{ user.IsStudent }");*/
            /*sql = sql.Replace("@TimeStamp", $"{ user.TimeStamp }");*/

            _database.SaveData(user, sql);
        }

        public void UpdateUser(UserModel user)
        {
            string sql = "update users set UserName=@UserName, Email=@Email, Password=@Password, Access=@Access, IsStudent=@IsStudent, TimeStamp=@TimeStamp " +
                "where UserId=@UserId";
            _database.UpdateData(user, sql);
        }

        public UserModel CreateUser(string UserName, string Email, string Password, int Access)
        {
            UserModel output = new UserModel();

            
                output.UserName = UserName;
          
                output.Email = Email;

                output.Password = Password;
              output.Access = Access;
           /* output.IsStudent = false;*/

            return output;
        }
        private bool ValidateName(string name)
        {
            bool output = true;
            char[] invalidCharacters = "`~!@#$%^&*()_+=0123456789<>,.?/\\|{}[]'\"".ToCharArray();

            if (name.Length < 2)
            {
                output = false;
            }

            if (name.IndexOfAny(invalidCharacters) >= 0)
            {
                output = false;
            }

            return output;
        }

    }
}
