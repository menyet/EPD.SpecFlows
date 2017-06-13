using System.ServiceModel;

namespace EPD.SpecApp.Services
{
    [ServiceContract]
    public interface IHelloWorldService
    {
        [OperationContract]
        string SayHello(string name);

        [OperationContract]
        Person[] GetPersons();

        [OperationContract]
        void AddPerson(Person person);
    }
}
