using System;
using System.Runtime.Serialization;

namespace Interna.Entity
{
    [Serializable]
    [DataContract]
    public class ObjetoAgencia : Core.Entity
    {
        [DataMember]
        public int id { get; set; }
        [DataMember]
        public int idTipoValidacion { get; set; }
        [DataMember]
        public int idEntrega { get; set; }

        public ObjetoAgencia() { }
        public ObjetoAgencia(int id, int idTipoValidacion, int idEntrega)
        {
            this.id = id;
            this.idTipoValidacion = idTipoValidacion;
            this.idEntrega = idEntrega;
        }
    }
}
