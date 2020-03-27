using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    public class RepositoryFactory
    {
        public static IRepository<T> Create<T>()
        {
            var repository = new Repository<T>();
            var dynamicProxy = new DynamicProxy<IRepository<T>>(repository)
            {
                Filter = (m => !m.Name.StartsWith("Get"))
            };
            return dynamicProxy.GetTransparentProxy() as IRepository<T>;
        }
    }
}

