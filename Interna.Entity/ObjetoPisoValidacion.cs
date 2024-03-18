using System;
using System.Runtime.Serialization;

namespace Interna.Entity
{
    [Serializable]
    [DataContract]
    public class ObjetoPisoValidacion : Core.Entity
    {
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public int IdTipoValidacion { get; set; }
        [DataMember]
        public int IdTipoResultado { get; set; }
        [DataMember]
        public DateTime FechaValidacion { get; set; }
        [DataMember]
        public DateTime FechaRecepcion { get; set; }
        [DataMember]
        public int IdGeoBandejaFisica { get; set; }


    }
}
