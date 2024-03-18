using System;
using System.Runtime.Serialization;

namespace Interna.Entity
{
    public class ReporteEntregaIntersucursales
    {
        [DataMember]
        public string codigoValijaEntrega { get; set; }
        [DataMember]
        public DateTime fechaEnvio { get; set; }
        [DataMember]
        public string expedicionOrigen { get; set; }
        [DataMember]
        public string expedicionDestino { get; set; }


    }
}
