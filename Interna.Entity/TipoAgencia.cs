using Interna.Entity.Interfaces;
using System;
using System.Runtime.Serialization;

namespace Interna.Entity
{
    [Serializable]
    [DataContract]
    class TipoAgencia : Core.Entity, ITipoAgencia
    {
        public Int16 iIdTipoAgencia { get; set; }
        public string sDescripcionTipoAgencia { get; set; }
    }
}
