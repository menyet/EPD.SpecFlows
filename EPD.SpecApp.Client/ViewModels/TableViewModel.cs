using System.Windows.Input;
using EPD.SpecApp.Client.Utils;
using EPD.SpecApp.Services;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;

namespace EPD.SpecApp.Client.ViewModels
{
    public class TableViewModel : ViewModelBase, ITabViewModel
    {
        private readonly IServiceInvokerFactory<IHelloWorldService> _serviceInvokerFactory;

        private string _name;
        private int _weight;
        private Person[] _persons;

        public TableViewModel(IServiceInvokerFactory<IHelloWorldService> serviceInvokerFactory)
        {
            _serviceInvokerFactory = serviceInvokerFactory;
            AddCommand = new RelayCommand(Add);
        }

        private void Add()
        {
            var person = new Person
            {
                Name = Name,
                Weight = Weight
            };

            _serviceInvokerFactory.Create().Invoke(x => x.AddPerson(person));

            Activate();
        }

        public string Name
        {
            get => _name;
            set { Set(() => Name, ref _name, value); }
        }

        public int Weight
        {
            get => _weight;
            set { Set(() => Weight, ref _weight, value); }
        }

        public void Activate()
        {
            var persons = _serviceInvokerFactory.Create().Invoke(x => x.GetPersons());

            Persons = persons;
        }

        public Person[] Persons
        {
            get => _persons;
            private set { Set(() => Persons, ref _persons, value); }
        }

        public string Title => "Table";

        public ICommand AddCommand { get; }
    }
}