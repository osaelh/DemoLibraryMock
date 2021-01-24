/*using Autofac;*/
using Autofac;
using DemoLibrary.Logic;
using DemoLibrary.Utilities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Demo
{
    public static class ContainerConfig
    {
        public static IContainer Configure()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<Application>().As<IApplication>();
            builder.RegisterType<UserProcessor>().As<IUserProcessor>();
            builder.RegisterType<DataAccess>().As<IDataAccess>();

            return builder.Build();
        }
    }
}
