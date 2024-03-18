using System;
using System.Runtime.Serialization;

namespace Interna.Entity
{
    [Serializable]
    [DataContract]
    public class ReporteRecorridoPisos : Core.Entity
    {
        [DataMember]
        public string Sede { get; set; }
        [DataMember]
        public string FechaInicio { get; set; }
        [DataMember]
        public string Servicio { get; set; }
        [DataMember]
        public string Recorrido { get; set; }
        [DataMember]
        public string HorarioInicio { get; set; }
        [DataMember]
        public string HorarioRetorno { get; set; }
        [DataMember]
        public string Colaborador { get; set; }
        [DataMember]
        public string HoraInicio { get; set; }
        [DataMember]
        public string HoraRetorno { get; set; }
        [DataMember]
        public string Estado { get; set; }
        [DataMember]
        public string Observacion { get; set; }
    }
}
