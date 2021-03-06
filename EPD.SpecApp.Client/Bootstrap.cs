﻿using EPD.SpecApp.Client.Utils;
using EPD.SpecApp.Client.ViewModels;
using EPD.SpecApp.Services;
using GalaSoft.MvvmLight.Ioc;

namespace EPD.SpecApp.Client
{
    public static class Bootstrap
    {
        public static void Start()
        {
            var container = SimpleIoc.Default;

            container.Register<IServiceInvokerFactory<IHelloWorldService>, ServiceInvokerFactory<IHelloWorldService>>();

            container.Register<MainViewModel>();

            container.Register<HelloViewModel>();
            container.Register<TableViewModel>();
        }
    }
}
