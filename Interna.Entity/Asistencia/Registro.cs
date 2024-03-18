using System;
using System.Runtime.Serialization;

namespace Interna.Entity
{
    [Serializable]
    [DataContract]
    public class Registro : Core.Entity
    {
        [DataMember]
        public int Resultado { get; set; }
        [DataMember]
        public string Mensaje { get; set; }
        [DataMember]
        public string Colaborador { get; set; }
        [DataMember]
        public string FechaHora { get; set; }
    }
}
