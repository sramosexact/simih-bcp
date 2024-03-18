using System;
using System.Runtime.Serialization;

namespace Interna.Entity
{
    [Serializable]
    [DataContract]
    public class AgenciaLote
    {
        [DataMember]
        public string sCodigoAgencia { get; set; }
        [DataMember]
        public string sDescripcion { get; set; }
    }
}
