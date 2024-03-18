using System;
using System.Runtime.Serialization;

namespace Interna.Entity
{
    [Serializable]
    [DataContract]
    public class ObjetoConfirmado : Core.Entity
    {
        [DataMember]
        public int ID { get; set; }
    }
}
