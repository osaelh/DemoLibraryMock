using System;
using System.Collections.Generic;
using Autofac.Extras.Moq;
using DemoLibrary.Logic;
using DemoLibrary.Models;
using DemoLibrary.Utilities;
using Moq;
using Xunit;
using System.Data.SqlClient;
using System.Configuration;

namespace DemoLibrarytests
{
    public class UserProcessorTests
    {
        [Fact]
        public void LoadPeople_ValidCall()
        {
            using (var mock= AutoMock.GetLoose())
            {
                mock.Mock<IDataAccess>()
                    .Setup(x=>x.LoadData<UserModel>("select * from Users"))
                    .Returns(GetSampleUsers());
                var cls = mock.Create<UserProcessor>();
                var expected = GetSampleUsers();
                var actual = cls.LoadUsers();

                Assert.True(actual != null);
               
                Assert.Equal(expected.Count, actual.Count);

                /*for (int i = 0; i < expected.Count; i++)
                {
                    Assert.Equal(expected[i].UserName, actual[i].UserName);
                    Assert.Equal(expected[i].Email, actual[i].Email);
                }*/
            }

           
        }

        private List<UserModel> GetSampleUsers()
        {
            List<UserModel> output = new List<UserModel>
            {
                new UserModel
                {
                    UserName= "osa",
                    Email= "osa@kng.com",
                    Password="123456"
                },
                new UserModel
                {
                    UserName= "otm",
                    Email= "otm@kng.com",
                    Password="123456"
                },
                new UserModel
                {UserName= "aub",
                    Email= "aub@kng.com",
                    Password="123456"
                },
                new UserModel
                {
                    UserName= "yaya",
                    Email= "yayaa@kng.com",
                    Password="123456"
                }
            };

            return output;
        }
    }
}
