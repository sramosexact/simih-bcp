using System;
using System.Runtime.Serialization;

namespace Interna.Entity
{
    [Serializable]
    [DataContract]
    public class ExportarAgencia
    {
        [DataMember]
        public string Autogenerado { get; set; }
        [DataMember]
        public string De { get; set; }
        [DataMember]
        public string Para { get; set; }
        [DataMember]
        public string Origen { get; set; }
        [DataMember]
        public string Destino { get; set; }
        [DataMember]
        public string Oficina { get; set; }
        [DataMember]
        public string Palomar { get; set; }
        [DataMember]
        public string Estado { get; set; }
        [DataMember]
        public string EstadoDocumento { get; set; }
        [DataMember]
        public string Entrega { get; set; }

        /*Control */
        public int TipoResultado { get; set; }
    }
}
