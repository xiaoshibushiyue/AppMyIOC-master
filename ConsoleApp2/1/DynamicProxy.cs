using System;
using System.Reflection;
using System.Runtime.Remoting.Messaging;
using System.Runtime.Remoting.Proxies;

namespace ConsoleApp2
{
    class DynamicProxy<T> : RealProxy
    {
        private readonly T _decorated;
        public DynamicProxy(T decorated)
          : base(typeof(T))
        {
            _decorated = decorated;
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
            Log("In Dynamic Proxy - Before executing '{0}'",
              methodCall.MethodName);
            try
            {
                var result = methodInfo.Invoke(_decorated, methodCall.InArgs);
                Log("In Dynamic Proxy - After executing '{0}' ",
                  methodCall.MethodName);
                return new ReturnMessage(result, null, 0,
                  methodCall.LogicalCallContext, methodCall);
            }
            catch (Exception e)
            {
                Log(string.Format(
                  "In Dynamic Proxy- Exception {0} executing '{1}'", e),
                  methodCall.MethodName);
                return new ReturnMessage(e, methodCall);
            }
        }
        ///筛选
        //public override IMessage Invoke(IMessage msg)
        //{
        //    var methodCall = msg as IMethodCallMessage;
        //    var methodInfo = methodCall.MethodBase as MethodInfo;
        //    if (!methodInfo.Name.StartsWith("Get"))
        //        Log("In Dynamic Proxy - Before executing '{0}'",
        //          methodCall.MethodName);
        //    try
        //    {
        //        var result = methodInfo.Invoke(_decorated, methodCall.InArgs);
        //        if (!methodInfo.Name.StartsWith("Get"))
        //            Log("In Dynamic Proxy - After executing '{0}' ",
        //              methodCall.MethodName);
        //        return new ReturnMessage(result, null, 0,
        //         methodCall.LogicalCallContext, methodCall);
        //    }
        //    catch (Exception e)
        //    {
        //        if (!methodInfo.Name.StartsWith("Get"))
        //            Log(string.Format(
        //              "In Dynamic Proxy- Exception {0} executing '{1}'", e),
        //              methodCall.MethodName);
        //        return new ReturnMessage(e, methodCall);
        //    }
        //}
    }
}
