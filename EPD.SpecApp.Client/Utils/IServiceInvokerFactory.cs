namespace EPD.SpecApp.Client.Utils
{
    public interface IServiceInvokerFactory<TService>
    {
        IServiceInvoker<TService> Create();
    }
}
