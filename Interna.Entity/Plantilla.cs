using Interna.Core;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Interna.Entity
{
    [Serializable]
    public class Plantilla : Interna.Core.Entity
    {
        #region Propiedades
        public int ID { get; set; }
        public int Cliente { get; set; }
        public int Expedicion { get; set; }
        public int TipoDocumento { get; set; }
        public string Nombre { get; set; }
        public string Llave { get; set; }
        public string Para { get; set; }
        public int Posicion { get; set; }
        public int Cabecera { get; set; }
        public int CreadoPor { get; set; }
        public DateTime CreadoEl { get; set; }
        public int EliminardoPor { get; set; }
        public DateTime EliminadoEl { get; set; }
        public int Activo { get; set; }
        public int TipoCampo { get; set; }
        public string Documento { get; set; }
        public string NombreCreador { get; set; }
        public string Eliminar { get; set; }

        #endregion

        public List<Plantilla> loPlantillas()
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();

            oP.Add(new SqlParameter("@IDCLIENTE", Cliente));
            return oSql.TablaParametro<Plantilla>("EXI_R_PLANTILLA_ACTIVA", oP);
        }

        public int cPlantilla()
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();

            oP.Add(new SqlParameter("@IDCLIENTE", Cliente));
            oP.Add(new SqlParameter("@IDEXPEDICION", Expedicion));
            oP.Add(new SqlParameter("@TIPODOCUMENTO", TipoDocumento));
            oP.Add(new SqlParameter("@NOMBRE", Nombre));
            oP.Add(new SqlParameter("@LLAVE", Llave));
            oP.Add(new SqlParameter("@PARA", Para));
            oP.Add(new SqlParameter("@POSICION", Posicion));
            oP.Add(new SqlParameter("@CABECERA", Cabecera));
            oP.Add(new SqlParameter("@CREADOPOR", CreadoPor));


            //iKey = Convert.ToInt32(oSql.Escalar("EXI_C_OBJETO_EXTERNO", oP));
            return Convert.ToInt32((new sql()).Escalar("EXI_C_PLANTILLA", oP));
            //return iKey;
        }

        public int uPlantilla()
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();

            oP.Add(new SqlParameter("@CODIGO", ID));
            oP.Add(new SqlParameter("@IDUSUARIO", CreadoPor));
            oP.Add(new SqlParameter("@IDEXPEDICION", Expedicion));
            return Convert.ToInt32((new sql()).Escalar("EXI_U_PLANTILLA_DESACTIVA", oP));
        }

    }

}
