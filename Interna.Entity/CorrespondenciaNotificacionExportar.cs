using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Interna.Entity
{
    [Serializable]
    [DataContract]
    public class CorrespondenciaNotificacionExportar
    {
        [DataMember]
        public string Autogenerado { get; set; }
        [DataMember]
        public string TipoDocumento { get; set; }
        [DataMember]
        public string BandejaVirtualDestino { get; set; }
        
    }
}
