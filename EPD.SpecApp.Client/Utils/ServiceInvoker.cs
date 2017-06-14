using System;

namespace EPD.SpecApp.Client.Utils
{

    public class ServiceInvoker<TService> : IServiceInvoker<TService>
    {
        private readonly TService _channel;

        public ServiceInvoker(TService channel)
        {
            _channel = channel;
        }

        public void Invoke(Action<TService> method)
        {
            method(_channel);
        }

        public TResult Invoke<TResult>(Func<TService, TResult> func)
        {
            return func(_channel);
        }
    }
}
