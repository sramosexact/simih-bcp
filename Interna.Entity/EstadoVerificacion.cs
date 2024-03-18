using Interna.Core;
using System;
using System.Runtime.Serialization;
namespace Interna.Entity
{
    [Serializable]
    [DataContract]
    public class EstadoVerificacion : Core.Entity
    {
        #region Propiedades

        [DataMember]
        public byte iIdEstadoVerificacion { get; set; }

        [DataMember]
        public string sDescripcionEstadoVerificacion { get; set; }

        #endregion

        #region Metodos

        public string ListarEstadoVerificacion()
        {
            return new sql().TablaJSON("PC_RECLAMO_LISTAR_ESTADO_VERIFICACION");
        }

        #endregion
    }
}
