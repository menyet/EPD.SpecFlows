using System.Collections.Generic;
using GalaSoft.MvvmLight;

namespace EPD.SpecApp.Client.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private ITabViewModel _selectedViewModel;

        public MainViewModel(HelloViewModel helloViewModel, TableViewModel tableViewModel)
        {
            ViewModels = new ITabViewModel[] {helloViewModel, tableViewModel};
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
}
