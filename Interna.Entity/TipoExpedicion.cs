using Interna.Core;
using Interna.Entity.Interfaces;

namespace Interna.Entity
{
    public class TipoExpedicion : Core.Entity, ITipoExpedicion
    {
        #region Propiedades

        public byte iIdTipoExpedicion { get; set; }
        public string sDescripcionTipoExpedicion { get; set; }

        #endregion

        #region Métodos
        //2022
        public string ListarTipoExpedicion()
        {
            sql oSql = new sql();
            return oSql.TablaJSON("SIMIH_MANTENIMIENTOEXPEDICION_R_TIPOEXPEDICION");
        }

        #endregion 

    }
}
