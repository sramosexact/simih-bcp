using System;
using System.Runtime.Serialization;

namespace Interna.Entity
{
    [Serializable]
    [DataContract]
    public class Empleado : Core.Entity
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Nombres { get; set; }
        [DataMember]
        public string ApellidoPaterno { get; set; }
        [DataMember]
        public string ApellidoMaterno { get; set; }
        [DataMember]
        public string Dni { get; set; }
        [DataMember]
        public TimeSpan HoraIngreso { get; set; }
        [DataMember]
        public int AreaId { get; set; }
        [DataMember]
        public int EstadoId { get; set; }
        [DataMember]
        public string Area { get; set; }
        [DataMember]
        public string Estado { get; set; }
    }
}
