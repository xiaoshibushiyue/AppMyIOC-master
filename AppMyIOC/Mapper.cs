using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppMyIOC
{
    public class Mapper
    {
        public static void Mapping()
        {
            //在此处调用容器维护映射关系
            MyIoc.Resgister<IStudent, Student>();
            
            //....
            //....
            //....
        }

        /// <summary>
        /// 获取接口类型对应的实例
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T GetInstance<T>()
        {
            return MyIoc.GetInstance<T>(typeof(T));
        }
    }
}
