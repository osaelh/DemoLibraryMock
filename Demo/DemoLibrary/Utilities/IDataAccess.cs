using System;
using System.Collections.Generic;
using System.Text;


namespace DemoLibrary.Utilities
{
    public  interface IDataAccess
    {
        List<T> LoadData<T>(string sql);
        void SaveData<T>(T person, string sql);
        void UpdateData<T>(T person, string sql);
    }
}
