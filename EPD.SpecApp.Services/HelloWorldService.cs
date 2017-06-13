using System.Linq;

namespace EPD.SpecApp.Services
{
    public class HelloWorldService : IHelloWorldService
    {
        public string SayHello(string name)
        {
            return $"Hello, {name}";
        }

        public Person[] GetPersons()
        {
            return Database.Instance.Persons.ToArray();
        }

        public void AddPerson(Person person)
        {
            Database.Instance.Persons.Add(person);
        }
    }
}
