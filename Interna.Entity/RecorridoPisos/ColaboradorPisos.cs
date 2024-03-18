using System;
using System.Runtime.Serialization;

namespace Interna.Entity
{
    [Serializable]
    [DataContract]
    public class ColaboradorPisos : Core.Entity
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Nombres { get; set; }
        [DataMember]
        public string ApellidoPaterno { get; set; }
        [DataMember]
        public string ApellidoMaterno { get; set; }
        [DataMember]
        public string Dni { get; set; }
        [DataMember]
        public int SedeId { get; set; }
        [DataMember]
        public string Sede { get; set; }
        [DataMember]
        public bool Activo { get; set; }
        [DataMember]
        public string Estado { get; set; }
    }
}
