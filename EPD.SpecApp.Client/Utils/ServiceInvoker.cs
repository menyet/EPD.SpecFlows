using System;
using System.ServiceModel;

namespace EPD.SpecApp.Client.Utils
{
    public class ServiceInvokerFactory<TService> : IServiceInvokerFactory<TService>
    {
        private readonly ChannelFactory<TService> _channelFactory;
        private const string ServiceAddress = "net.tcp://localhost:6339/MyService";

        public ServiceInvokerFactory()
        {
            var binding = new NetTcpBinding
            {
                Security = { Mode = SecurityMode.None },
                CloseTimeout = TimeSpan.FromMinutes(10),
                OpenTimeout = TimeSpan.FromMinutes(10),
                ReceiveTimeout = TimeSpan.FromMinutes(10),
                SendTimeout = TimeSpan.FromMinutes(10)
            };

            _channelFactory = new ChannelFactory<TService>(binding, ServiceAddress);
        }


        public IServiceInvoker<TService> Create()
        {
            return new ServiceInvoker<TService>(_channelFactory.CreateChannel());
        }
    }

    public interface IServiceInvokerFactory<TService>
    {
        IServiceInvoker<TService> Create();
    }

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

    public interface IServiceInvoker<out TService>
    {
        void Invoke(Action<TService> method);

        TResult Invoke<TResult>(Func<TService, TResult> func);
    }
}
