namespace EPD.SpecApp.Services.Host
{
    public class HelloWorldService : IHelloWorldService
    {
        public string SayHello(string name)
        {
            return $"Hello, {name}";
        }
    }
}
