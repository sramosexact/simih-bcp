using Interna.Core;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Interna.Entity
{
    public class Operario : Usuario
    {

        #region propiedades
        //public int IdExpedicion { get; set; }
        #endregion

        public List<Operario> oLista(Operario oOperario)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@EXPEDICION", oOperario.IdExpedicion));
            List<Operario> lista = new List<Operario>();
            lista = oSql.TablaParametro<Operario>("EXI_R_OPERARIO", oP);
            return lista;
        }
        // Funcional - frmNuevaEntregaPisos - frmNuevaEntregaSucursal
        //2022
        public String rListaOperario(int iExpedicion)
        {
            sql oSql = new sql();

            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@EXPEDICION", iExpedicion));
            return oSql.TablaParametroJSON("EXI_R_OPERARIO", oP);
        }
    }
}
