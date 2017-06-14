using System;

namespace EPD.SpecApp.Client.Utils
{
    public interface IServiceInvoker<out TService>
    {
        void Invoke(Action<TService> method);

        TResult Invoke<TResult>(Func<TService, TResult> func);
    }
}
