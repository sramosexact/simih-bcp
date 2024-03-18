using System;
using System.Runtime.Serialization;

namespace Interna.Entity
{
    [Serializable]
    [DataContract]
    public class TipoDestinoExterno : Core.Entity
    {
        public byte iIdTipoDestinoExterno { get; set; }
        public string sDescripcionTipoDestinoExterno { get; set; }

    }
}
