using Interna.Core;
using System;
using System.Runtime.Serialization;

namespace Interna.Entity
{
    [Serializable]
    [DataContract]
    public class TipoResponsable : Core.Entity
    {
        #region Propiedades

        [DataMember]
        public byte iIdTipoResponsable { get; set; }

        [DataMember]
        public string sDescripcionTipoResponsable { get; set; }

        [DataMember]
        public byte iActivoTipoResponsable { get; set; }


        #endregion

        #region Metodos

        public string ListarTipoResponsableActivo()
        {

            return new sql().TablaJSON("PC_RECLAMO_LISTAR_TIPO_RESPONSABLE");
        }

        #endregion
    }
}
