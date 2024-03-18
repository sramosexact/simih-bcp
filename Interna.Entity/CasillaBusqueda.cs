using System.Runtime.Serialization;

namespace Interna.Entity
{
    [DataContract]
    public class CasillaBusqueda
    {
        [DataMember]
        public int iId { get; set; }
        [DataMember]
        public string sDescripcion { get; set; }
    }
}
