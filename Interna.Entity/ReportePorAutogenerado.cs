using System;
using System.Runtime.Serialization;

namespace Interna.Entity
{
    [Serializable]
    [DataContract]
    public class ReportePorAutogenerado
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string CodigoDocumento { get; set; }
        [DataMember]
        public string Tipo { get; set; }
        [DataMember]
        public string Estado { get; set; }
        [DataMember]
        public string BandejaRemitente { get; set; }
        [DataMember]
        public string UbicacionOrigen { get; set; }
        [DataMember]
        public string BandejaDestino { get; set; }
        [DataMember]
        public string UbicacionDestino { get; set; }
        [DataMember]
        public DateTime FechaCreacion { get; set; }
        [DataMember]
        public DateTime FechaCustodiaOrigen { get; set; }
        [DataMember]
        public DateTime FechaCustodiaDestino { get; set; }
        [DataMember]
        public DateTime FechaRutaExpedicion { get; set; }
        [DataMember]
        public DateTime FechaRutaPisos { get; set; }
        [DataMember]
        public DateTime FechaRutaAgencia { get; set; }
        [DataMember]
        public DateTime FechaRecibido { get; set; }
        [DataMember]
        public DateTime FechaConfirmado { get; set; }
        [DataMember]
        public DateTime FechaRetiro { get; set; }
        [DataMember]
        public string CodigoAgenciaOrigen { get; set; }
        [DataMember]
        public string AgenciaOrigen { get; set; }
        [DataMember]
        public string CodigoAgenciaDestino { get; set; }
        [DataMember]
        public string AgenciaDestino { get; set; }
        [DataMember]
        public string ExpedicionCustodiaOrigen { get; set; }
        [DataMember]
        public string ExpedicionCustodiaDestino { get; set; }
    }
}
