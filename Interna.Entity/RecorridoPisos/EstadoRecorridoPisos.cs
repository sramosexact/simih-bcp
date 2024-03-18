using System;
using System.Runtime.Serialization;

namespace Interna.Entity
{
    [Serializable]
    [DataContract]
    public class EstadoRecorridoPisos : Core.Entity
    {
        [DataMember]
        public bool Id { get; set; }
        [DataMember]
        public string Descripcion { get; set; }
    }
}
