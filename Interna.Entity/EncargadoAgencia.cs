using Interna.Entity.Interfaces;
using System;
using System.Runtime.Serialization;

namespace Interna.Entity
{
    [Serializable]
    [DataContract]
    public class EncargadoAgencia : Interna.Core.Entity, IEncargadoAgencia
    {
        #region Variables
        [DataMember]
        public Int16 iIdEncargadoAgencia { get; set; }
        [DataMember]
        public int iIdUsuario { get; set; }
        [DataMember]
        public int iIdAgencia { get; set; }
        #endregion


    }
}
