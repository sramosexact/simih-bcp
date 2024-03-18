using Interna.Core;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Interna.Entity
{
    public class Mensajeria : Interna.Core.Entity
    {
        #region Propiedades

        public int ID { get; set; }
        public string Descripcion { get; set; }
        public int TipoTransporte { get; set; }

        #endregion
        public List<Mensajeria> oListaMensajeria()
        {
            sql oSql = new sql();
            //List<SqlParameter> oP = new List<SqlParameter>();
            //oP.Add(new SqlParameter("@TIPOTRANSPORTE", oM.TipoTransporte));
            List<Mensajeria> lista = new List<Mensajeria>();
            lista = oSql.Tabla<Mensajeria>("EXI_R_MENSAJERIA");
            return lista;
        }
        public List<Mensajeria> oListaTipoMensajeria(int tipoEntrega)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@TIPOTRANSPORTE", tipoEntrega));
            List<Mensajeria> lista = new List<Mensajeria>();
            lista = oSql.TablaParametro<Mensajeria>("EXI_R_MENSAJERIA_TIPO", oP);
            return lista;
        }


        public List<Mensajeria> rMensajeriaServicio()
        {
            sql oSql = new sql();

            List<Mensajeria> lista = new List<Mensajeria>();
            lista = oSql.Tabla<Mensajeria>("EXI_R_MENSAJERIA_SERVICIO");
            return lista;

        }
    }
}
