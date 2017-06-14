using EPD.SpecApp.Client.Utils;
using EPD.SpecApp.Services;
using GalaSoft.MvvmLight;

namespace EPD.SpecApp.Client.ViewModels
{
    public class HelloViewModel : ViewModelBase, ITabViewModel
    {
        private readonly IServiceInvokerFactory<IHelloWorldService> _serviceInvokerFactory;

        private string _text;
        private string _name;

        public HelloViewModel(IServiceInvokerFactory<IHelloWorldService> serviceInvokerFactory)
        {
            _serviceInvokerFactory = serviceInvokerFactory;
        }

        public string Name
        {
            get { return _name; }
            set
            {
                if (Set(() => Name, ref _name, value))
                {
                    UpdateMessage();
                }
            }
        }

        private void UpdateMessage()
        {
            Text = _serviceInvokerFactory.Create().Invoke(x => x.SayHello(Name));
        }

        public string Text
        {
            get => _text;
            set { Set(() => Text, ref _text, value); }
        }

        public void Activate()
        {
            Text = string.Empty;
        }

        public string Title => "Hello";
    }
}