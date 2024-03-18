using System;
using System.Runtime.Serialization;

namespace Interna.Entity
{
    [Serializable]
    [DataContract]
    public class Horario : Core.Entity
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Descripcion { get; set; }
        [DataMember]
        public TimeSpan HoraInicio { get; set; }
        [DataMember]
        public TimeSpan HoraFin { get; set; }
        [DataMember]
        public int SedeId { get; set; }
        [DataMember]
        public int ServicioId { get; set; }
        [DataMember]
        public Boolean Activo { get; set; }
        [DataMember]
        public string Sede { get; set; }
        [DataMember]
        public string Servicio { get; set; }
    }
}
