using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppMyIOC
{
    public class MyIoc
    {
        /// <summary>
        /// 声明容器
        /// </summary>
        private static Dictionary<Type, Type> container = new Dictionary<Type, Type>();

        /// <summary>
        /// 容器注册方法（将接口类型，与接口实现类型 放入容器中）
        /// </summary>
        /// <typeparam name="TInterface"></typeparam>
        /// <typeparam name="TImplement"></typeparam>
        public static void Resgister<TInterface,TImplement>()
        {
            container.Add(typeof(TInterface), typeof(TImplement));
        }

        /// <summary>
        /// 根据容器中value的类型 ，通过反射创建实例
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="typeInterface"></param>
        /// <returns></returns>
        public static T GetInstance<T>(Type typeInterface)
        {

            var typeImplement = container.Keys.Contains(typeInterface) ? container[typeInterface] : null;
            if (typeImplement == null)
            {
                throw new Exception("未绑定相关类型");
            }
            var constructor = typeImplement.GetConstructors()[0];

            return (T)constructor.Invoke(null);
        }
    }
}
