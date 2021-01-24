using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Data;
using Dapper;
using System.Linq;
using System.Data.SqlClient;
using DemoLibrary.Models;

namespace DemoLibrary.Utilities
{

    public class DataAccess : IDataAccess
    {
        public static System.Configuration.ConnectionStringSettingsCollection ConnectionStrings { get; }
        public List<T> LoadData<T>(string sql)
        {
            using (IDbConnection cn = new System.Data.SqlClient.SqlConnection(LoadConnectionString()))
            {
                var output = cn.Query<T>(sql, new DynamicParameters()).ToList();
                return output;
            }
        }

        public void SaveData<T>(T users,string sql)
        {
            using (IDbConnection cn = new SqlConnection(LoadConnectionString()))
            {
               cn.Execute(sql, users);
            }
        }

        public void UpdateData<T>(T person, string sql)
        {
            using (IDbConnection cn = new System.Data.SqlClient.SqlConnection(LoadConnectionString()))
            {
                cn.Execute(sql, person);
            }
        }
        
        static string LoadConnectionString(string name = "DDB")
        {
            
            return  $"Server=(localdb)\\MSSQLLocalDB;Database={name};Trusted_Connection=True";
        }
    }
}
