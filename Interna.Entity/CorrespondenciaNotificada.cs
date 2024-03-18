using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Interna.Entity
{
    [Serializable]
    [DataContract]
    public  class CorrespondenciaNotificada : Core.Entity
    {
        [DataMember]
        public string autogenerado { get;set; }
    }
}
