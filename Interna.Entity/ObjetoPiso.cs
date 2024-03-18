using System;
using System.Runtime.Serialization;

namespace Interna.Entity
{
    [Serializable]
    [DataContract]
    public class ObjetoPiso : Core.Entity
    {
        [DataMember]
        public string Autogenerado { get; set; }
        [DataMember]
        public string EntregaFecha { get; set; }
        [DataMember]
        public string EntregaHora { get; set; }
        [DataMember]
        public string EntregaIdentificacion { get; set; }
        [DataMember]
        public string EntregaObservacion { get; set; }
        [DataMember]
        public string seleccion { get; set; }
        [DataMember]
        public int IdTipoResultado { get; set; }
        [DataMember]
        public string EntregaIdentificacionCifrada { get; set; }

        [DataMember]
        public string UsuarioCifrado { get; set; }
        [DataMember]
        public string TipoEntrega { get; set; }


    }
}
