using System;
using System.Runtime.Serialization;

namespace Interna.Entity
{
    [Serializable]
    [DataContract]
    public class ReporteAsistencia : Core.Entity
    {
        [DataMember]
        public string AreaColaborador { get; set; }
        [DataMember]
        public string FechaIngreso { get; set; }
        [DataMember]
        public string Dni { get; set; }
        [DataMember]
        public string Colaborador { get; set; }
        [DataMember]
        public string HoraIngresoBase { get; set; }
        [DataMember]
        public string HoraIngreso { get; set; }
        [DataMember]
        public string FechaSalida { get; set; }
        [DataMember]
        public string HoraSalida { get; set; }
        [DataMember]
        public string Estado { get; set; }
        [DataMember]
        public string Ubicacion { get; set; }
        [DataMember]
        public string Observacion { get; set; }
    }
}
