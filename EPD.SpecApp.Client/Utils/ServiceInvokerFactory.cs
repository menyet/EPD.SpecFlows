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
}
