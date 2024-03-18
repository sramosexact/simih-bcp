using System;
using System.Runtime.Serialization;


namespace Interna.Entity
{
    [Serializable]
    [DataContract]
    public class Bandeja
    {
        [DataMember]
        public string nombre { get; set; }
        [DataMember]
        public string tipo { get; set; }
    }
}
