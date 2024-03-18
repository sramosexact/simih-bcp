using Interna.Core;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Runtime.Serialization;

namespace Interna.Entity
{
    [Serializable]
    [DataContract]
    public class ModuloCreacion : Core.Entity
    {
        #region Propiedades 

        [DataMember]
        public int iId { get; set; }

        [DataMember]
        public string sDescripcion { get; set; }

        #endregion

        #region Métodos
        //2022
        public string ListarModulosCreacion()
        {
            return new sql().TablaJSON("SIMIH_MANTENIMIENTOTIPODOCUMENTO_R_MODULOCREACION");
        }
        //2022
        public string ListarModulosCreacionPorTipoDocumento(TipoDocumento oTipoDocumento)
        {
            List<SqlParameter> lP = new List<SqlParameter>();
            lP.Add(new SqlParameter("@iIdTipoDocumento", oTipoDocumento.iIdTipoDocumento));
            return new sql().TablaParametroJSON("SIMIH_MANTENIMIENTOTIPODOCUMENTO_R_MODULOCREACION_POR_TIPODOCUMENTO", lP);
        }

        #endregion
    }
}
