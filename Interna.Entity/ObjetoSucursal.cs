using System;
using System.Runtime.Serialization;

namespace Interna.Entity
{
    [Serializable]
    [DataContract]
    public class ObjetoSucursal : Core.Entity
    {
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public int TipoValidacion { get; set; }

    }
}
