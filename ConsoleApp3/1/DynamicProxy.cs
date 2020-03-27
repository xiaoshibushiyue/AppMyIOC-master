using System;
using System.Reflection;
using System.Runtime.Remoting.Messaging;
using System.Runtime.Remoting.Proxies;

namespace ConsoleApp3
{
    /// <summary>
    /// 这是一个筛选代理
    /// </summary>
    /// <typeparam name="T"></typeparam>
    class DynamicProxy<T> : RealProxy
    {
        private readonly T _decorated;
        private Predicate<MethodInfo> _filter;
        public DynamicProxy(T decorated)
          : base(typeof(T))
        {
            _decorated = decorated;
            _filter = m => true;
        }
        public Predicate<MethodInfo> Filter
        {
            get { return _filter; }
            set
            {
                if (value == null)
                    _filter = m => true;
                else
                    _filter = value;
            }
        }
        private void Log(string msg, object arg = null)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(msg, arg);
            Console.ResetColor();
        }
        public override IMessage Invoke(IMessage msg)
        {
            var methodCall = msg as IMethodCallMessage;
            var methodInfo = methodCall.MethodBase as MethodInfo;
            if (_filter(methodInfo))
                Log("In Dynamic Proxy - Before executing '{0}'",
                  methodCall.MethodName);
            try
            {
                var result = methodInfo.Invoke(_decorated, methodCall.InArgs);
                if (_filter(methodInfo))
                    Log("In Dynamic Proxy - After executing '{0}' ",
                      methodCall.MethodName);
                return new ReturnMessage(result, null, 0,
                  methodCall.LogicalCallContext, methodCall);
            }
            catch (Exception e)
            {
                if (_filter(methodInfo))
                    Log(string.Format(
                      "In Dynamic Proxy- Exception {0} executing '{1}'", e),
                      methodCall.MethodName);
                return new ReturnMessage(e, methodCall);
            }
        }
    }
}
