using System;
using System.Runtime.Remoting.Activation;
using System.Runtime.Remoting.Contexts;
using System.Runtime.Remoting.Messaging;
using System.Security.Principal;
using System.Threading;

namespace ConsoleApp2
{
    
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(
              "***\r\n Begin program - logging and authentication\r\n");
            Console.WriteLine("\r\nRunning as admin");
            Thread.CurrentPrincipal =
              new GenericPrincipal(new GenericIdentity("Administrator"),
              new[] { "ADMIN" });
            IRepository<Customer> customerRepository =
              RepositoryFactory.Create<Customer>();
            var customer = new Customer
            {
                Id = 1,
                Name = "Customer 1",
                Address = "Address 1"
            };
            customerRepository.Add(customer);
            customerRepository.Update(customer);
            customerRepository.Delete(customer);
            Console.WriteLine("\r\nRunning as user");
            Thread.CurrentPrincipal =
              new GenericPrincipal(new GenericIdentity("NormalUser"),
              new string[] { });
            customerRepository.Add(customer);
            customerRepository.Update(customer);
            customerRepository.Delete(customer);
            Console.WriteLine(
              "\r\nEnd program - logging and authentication\r\n***");
            Console.ReadLine();
        }
    }

  
}