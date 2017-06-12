using System.Windows;
using EPD.SpecApp.Client.ViewModels;
using GalaSoft.MvvmLight.Ioc;

namespace EPD.SpecApp.Client
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Bootstrap.Start();
            
            DataContext = SimpleIoc.Default.GetInstance<MainViewModel>();
        }
    }
}
