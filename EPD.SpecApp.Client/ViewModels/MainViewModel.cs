using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using EPD.SpecApp.Client.Utils;
using EPD.SpecApp.Services;
using GalaSoft.MvvmLight;

namespace EPD.SpecApp.Client.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private ITabViewModel _selectedViewModel;

        public MainViewModel(TableViewModel tableViewModel)
        {
            ViewModels = new[] {tableViewModel};
        }

        public IReadOnlyCollection<ITabViewModel> ViewModels { get; }

        public ITabViewModel SelectedTabViewModel
        {
            get { return _selectedViewModel; }
            set
            {
                if (Set(() => SelectedTabViewModel, ref _selectedViewModel, value))
                {
                    SelectedTabViewModel.Activate();
                }
            }
        }
    }

    public class TableViewModel : ViewModelBase, ITabViewModel
    {
        private readonly IServiceInvokerFactory<IHelloWorldService> _serviceInvokerFactory;

        private string _text;
        private string _name;

        public TableViewModel(IServiceInvokerFactory<IHelloWorldService> serviceInvokerFactory)
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
    }

    public interface ITabViewModel
    {
        void Activate();
    }
}
