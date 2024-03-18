using System;
using System.Runtime.Serialization;

namespace Interna.Entity
{
    [Serializable]
    [DataContract]
    public class EntregaGrupo : Core.Entity
    {
        [DataMember]
        public int iId { get; set; }
        [DataMember]
        public int iIdEntrega { get; set; }

    }
}
