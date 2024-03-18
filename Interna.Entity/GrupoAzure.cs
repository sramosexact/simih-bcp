using System;
using System.Runtime.Serialization;

namespace Interna.Entity
{
    [Serializable]
    [DataContract]
    public class GrupoAzure : Core.Entity
    {
        [DataMember]
        public int iId { get; set; }
        [DataMember]
        public string sDescripcion { get; set; }
        [DataMember]
        public string sValorGrupo { get; set; }
    }
}
