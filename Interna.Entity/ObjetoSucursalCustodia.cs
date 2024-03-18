using System;
using System.Runtime.Serialization;

namespace Interna.Entity
{
    [Serializable]
    [DataContract]
    public class ObjetoSucursalCustodia : Core.Entity
    {
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public DateTime fechaResultado { get; set; }

    }
}

