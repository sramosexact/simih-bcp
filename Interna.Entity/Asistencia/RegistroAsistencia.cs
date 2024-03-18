using System;
using System.Runtime.Serialization;

namespace Interna.Entity
{
    [Serializable]
    [DataContract]
    public class RegistroAsistencia
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Colaborador { get; set; }
        [DataMember]
        public string FechaIngreso { get; set; }
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
        [DataMember]
        public int EstadoId { get; set; }
        [DataMember]
        public int EmpleadoId { get; set; }
        [DataMember]
        public int UbicacionId { get; set; }
        [DataMember]
        public string Accion { get; set; }
    }
}
