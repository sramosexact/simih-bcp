using Interna.Core;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Runtime.Serialization;

namespace Interna.Entity
{
    [Serializable]
    [DataContract]
    public class UsuarioFac : Interna.Core.Entity
    {
        #region PROPIEDADES

        [DataMember]
        public int ID { get; set; }

        [DataMember]
        public int IdGeo { get; set; }


        [DataMember]
        public String Descripcion { get; set; }

        [DataMember]
        public int PorEnviar { get; set; }

        [DataMember]
        public int PorRecibir { get; set; }

        [DataMember]
        public string Calle { get; set; }

        [DataMember]
        public string Distrito { get; set; }

        [DataMember]
        public string Provincia { get; set; }

        [DataMember]
        public string Departamento { get; set; }

        public List<Usuario> Detalle { get; set; }

        [DataMember]
        public string Correo { get; set; }

        #endregion

        public UsuarioFac()
        {
        }

        public List<UsuarioFac> rConsultaTotal(int RecordIndex, int PageWidth)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@RECORDINDEX", RecordIndex));
            oP.Add(new SqlParameter("@WIDTH", PageWidth));
            return oSql.TablaParametro<UsuarioFac>("EXI_R_CONSULTA_FAC_TOTAL", oP);
        }
        public int rConsultaTotalCONTAR()
        {
            sql oSql = new sql();
            return (int)oSql.Escalar("EXI_R_CONSULTA_FAC_TOTAL_CONTAR");
        }

        /*Implementado 01/10/2015 */

        public List<String> rConsultaTotalJson()
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            return oSql.ListaTablaJSON("PEXI_R_CONSULTA_FAC_TOTAL");
        }
    }
}

