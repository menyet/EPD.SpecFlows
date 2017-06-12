using EPD.SpecApp.Client.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPD.SpecApp.SpecFlows.Utils
{
    public class ServiceInvoker<T> : IServiceInvoker<T>
    {
        private readonly T _channel;

        public ServiceInvoker(T channel)
        {
            _channel = channel;
        }

        public void Invoke(Action<T> method)
        {
            method(_channel);
        }

        public TResult Invoke<TResult>(Func<T, TResult> func)
        {
            return func(_channel);
        }
    }

    public class ServiceInvokerFactory<T> : IServiceInvokerFactory<T>
    {
        private readonly T _channel;

        public ServiceInvokerFactory(T channel)
        {
            _channel = channel;
        }

        public IServiceInvoker<T> Create()
        {
            return new ServiceInvoker<T>(_channel);
        }
    }
}
