using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppMyIOC
{
    class Program
    {       
        static void Main(string[] args)
        {
            //可以写在程序启动入口，比如web中的Global.asax文件
            Mapper.Mapping();
            

            var op = new OprateController();
            Console.WriteLine(op.OprateRead());
            Console.WriteLine(op.OprateWrite());
            Console.ReadKey();
        }
    }
}
