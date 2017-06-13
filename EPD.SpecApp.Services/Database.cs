using System.Collections.ObjectModel;

namespace EPD.SpecApp.Services
{
    public class Database
    {
        public Collection<Person> Persons { get; }

        private Database()
        {
            Persons = new Collection<Person>();
        }

        public static Database Instance { get; } = new Database();
    }
}