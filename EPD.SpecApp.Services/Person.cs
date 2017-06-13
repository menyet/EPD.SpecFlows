using System.Runtime.Serialization;

namespace EPD.SpecApp.Services
{
    [DataContract]
    public class Person
    {
        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public int Weight { get; set; }
    }
}