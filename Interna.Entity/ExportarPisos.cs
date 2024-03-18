using System.Runtime.Serialization;

namespace Interna.Entity
{
    [DataContract]
    public class ExportarPisos
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
        public string Bandeja { get; set; }
        [DataMember]
        public string Estado { get; set; }
        [DataMember]
        public string EstadoDocumento { get; set; }
        [DataMember]
        public string Validacion { get; set; }
        [DataMember]
        public string Campo { get; set; }
        [DataMember]
        public string Entrega { get; set; }

        public string Observacacion { get; set; }

        [DataMember]
        public string fecha { get; set; }

        [DataMember]
        public string Fecha { get; set; }

        /*Control */
        public int TipoResultado { get; set; }
        [DataMember]
        public int ID { set; get; }




    }
}
