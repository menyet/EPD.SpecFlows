using System;
using System.Linq;
using System.ServiceModel;

namespace EPD.SpecApp.Services.Host
{
    class Program
    {


        static void Main(string[] args)
        {
            //ServiceHost hostDefault = new
            //    ServiceHost(typeof(HelloWorldService));

            //TimeSpan closeTimeout = hostDefault.CloseTimeout;

            //TimeSpan openTimeout = hostDefault.OpenTimeout;


            //ServiceAuthorizationBehavior authorization =
            //    hostDefault.Authorization;

            //ServiceCredentials credentials =
            //    hostDefault.Credentials;

            //ServiceDescription description =
            //    hostDefault.Description;


            //int manualFlowControlLimit =
            //    hostDefault.ManualFlowControlLimit;


            NetTcpBinding portsharingBinding = new NetTcpBinding()
            {
                Security = {Mode = SecurityMode.None},
                CloseTimeout = TimeSpan.FromMinutes(10),
                OpenTimeout = TimeSpan.FromMinutes(10),
                ReceiveTimeout = TimeSpan.FromMinutes(10),
                SendTimeout = TimeSpan.FromMinutes(10)
            };
            //hostDefault.AddServiceEndpoint(
            //    typeof(IHelloWorldService),
            //    portsharingBinding,
            //    "net.tcp://localhost/MyService");


            var a = new[]
            {
                "Clifton Holden",
                "Jimmy Lara",
                "Eric Willis",
                "Nelson Huffman",
                "Marc McCullough",
                "Bob Larsen",
                "Stephen Henderson",
                "Jimmy Goodman",
                "Fernando Love",
                "Logan Huff"
            };

            var p = a.Select(n => new Person { Name = n, Weight = (n.Length - 5) * 10 + n.Length % 9 });

            foreach (var person in p)
            {
                Database.Instance.Persons.Add(person);
            }

           //int newLimit = hostDefault.IncrementManualFlowControlLimit(100);

            using (ServiceHost serviceHost = new ServiceHost(typeof(HelloWorldService)))
            {
                try
                {
                    serviceHost.AddServiceEndpoint(
                        typeof(IHelloWorldService),
                        portsharingBinding,
                        "net.tcp://localhost:6339/MyService");
                    
                    // Open the ServiceHost to start listening for messages.
                    serviceHost.Open();
                    // The service can now be accessed.
                    Console.WriteLine("The service is ready.");
                    Console.WriteLine("Press <ENTER> to terminate service.");
                    Console.ReadLine();

                    // Close the ServiceHost.
                    serviceHost.Close();
                }
                catch (TimeoutException timeProblem)
                {
                    Console.WriteLine(timeProblem.Message);
                    Console.ReadLine();
                }
                catch (CommunicationException commProblem)
                {
                    Console.WriteLine(commProblem.Message);
                    Console.ReadLine();
                }
            }
        }
    }
}
