using Interna.Core;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Runtime.Serialization;

namespace Interna.Entity
{
    [Serializable]
    [DataContract]
    public class Fac : Interna.Core.Entity
    {
        [DataMember]
        public int ID { get; set; }

        [DataMember]
        public int idGeo { get; set; }

        [DataMember]
        public String Descripcion { get; set; }

        public List<Geo> rVerGeoFac(int idCliente, int idUsuario)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@IDCLIENTE", idCliente));
            oP.Add(new SqlParameter("@IDUSUARIO", idUsuario));
            return oSql.TablaParametro<Geo>("EXI_R_GEO_FAC", oP);
        }
        /***************************************/

        public string rVerGeoFacJSON(int idCliente, int idUsuario)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@IDCLIENTE", idCliente));
            oP.Add(new SqlParameter("@IDUSUARIO", idUsuario));
            return oSql.TablaParametroJSON("EXI_R_GEO_FAC", oP);
        }

        public List<Objeto> rVerCorrespondenciaRecibidasFAC(int opc, int idGeo, int idEntrega)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@IDOFC", idGeo));
            oP.Add(new SqlParameter("@OPC", opc));
            oP.Add(new SqlParameter("@IDENTREGA", idEntrega));
            return oSql.TablaParametro<Objeto>("EXI_R_OBJETO_RECIBIDOS_FAC", oP);
        }

        /***************************************/

        public string rVerCorrespondenciaRecibidasFACJSON(int idGeo, int opc, int idEntrega)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@IDOFC", idGeo));
            oP.Add(new SqlParameter("@OPC", opc));
            oP.Add(new SqlParameter("@IDENTREGA", idEntrega));
            return oSql.TablaParametroJSON("EXI_R_OBJETO_RECIBIDOS_FAC", oP);
        }

        /***************************************/

        public List<Objeto> rVerCorrespondenciaRecibidasFAC_SALIDA(int idGeo)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@IDOFC", idGeo));
            return oSql.TablaParametro<Objeto>("EXI_R_OBJETO_RECIBIDOS_FAC_SALIDA", oP);
        }

        /***************************************/

        public string rVerCorrespondenciaRecibidasFAC_SALIDAJSON(int idGeo)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@IDOFC", idGeo));
            return oSql.TablaParametroJSON("EXI_R_OBJETO_RECIBIDOS_FAC_SALIDA", oP);
        }

        public List<Objeto> rVerBandejaFac()
        {
            sql oSql = new sql();
            return oSql.Tabla<Objeto>("EXI_R_BANDEJAS_FAC");
        }


        public List<Usuario> rVerBandejasUsuFac(int id)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@IDUSUARIO", id));
            return oSql.TablaParametro<Usuario>("EXI_R_USUARIO_FAC_ID", oP);
        }

        public List<Objeto> rVerCorrespondenciaFACHistorica(int opcion, int iGeo, int nDias)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@OPCION", opcion));
            oP.Add(new SqlParameter("@IDOFC", iGeo));
            oP.Add(new SqlParameter("@NDIA", nDias));
            return oSql.TablaParametro<Objeto>("EXI_R_OBJETO_FAC_HISTORICA_TOTAL", oP);
        }

        public string rVerObjetoDocFACHistoricaTotal(int opcion, int iGeo, string fecha_ini, string fecha_fin)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@OPCION", opcion));
            oP.Add(new SqlParameter("@IDOFC", iGeo));
            oP.Add(new SqlParameter("@FECHA_INICIO", fecha_ini));
            oP.Add(new SqlParameter("@FECHA_FIN", fecha_fin));
            return oSql.TablaParametroJSON("WEXI_R_OBJETO_FAC_HISTORICA_TOTAL", oP);
        }
        //introducido 27/08/2015
        public String rVerBandejasUsuFacJson(int id)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@IDUSUARIO", id));
            return oSql.TablaParametroJSON("EXI_R_USUARIO_FAC_ID", oP);
        }

        public string rFacNotificacionesJson(int id)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@IDUSU", id));
            return oSql.TablaParametroJSON("WEXI_R_OBJETO_RECIBIDOS_FAC_NOTIFICACIONES", oP);
        }

    }
}
