using System;
using System.Runtime.Serialization;

namespace Interna.Entity
{
    [Serializable]
    [DataContract]
    public class ObjetoSucursalCustodiaMasivo : ObjetoSucursalCustodia
    {
        [DataMember]
        public int IdEntrega { get; set; }
    }
}
