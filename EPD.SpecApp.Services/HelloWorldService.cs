namespace EPD.SpecApp.Services
{
    public class HelloWorldService : IHelloWorldService
    {
        public string SayHello(string name)
        {
            return $"Hello, {name}";
        }
    }
}
