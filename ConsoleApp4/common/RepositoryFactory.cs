using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public class RepositoryFactory
    {
        private static void Log(string msg, object arg = null)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(msg, arg);
            Console.ResetColor();
        }
        public static IRepository<T> Create<T>()
        {
            var repository = new Repository<T>();
            var dynamicProxy = new DynamicProxy<IRepository<T>>(repository);
            dynamicProxy.BeforeExecute += (s, e) => Log(
              "Before executing '{0}'", e.MethodName);
            dynamicProxy.AfterExecute += (s, e) => Log(
              "After executing '{0}'", e.MethodName);
            dynamicProxy.ErrorExecuting += (s, e) => Log(
              "Error executing '{0}'", e.MethodName);
            dynamicProxy.Filter = m => !m.Name.StartsWith("Get");
            return dynamicProxy.GetTransparentProxy() as IRepository<T>;
        }
    }
}

