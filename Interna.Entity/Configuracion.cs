using Interna.Core;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Runtime.Serialization;

namespace Interna.Entity
{
    [Serializable]
    [DataContract]
    public class Configuracion : Interna.Core.Entity
    {
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public string Descripcion { get; set; }
        [DataMember]
        public string sValor { get; set; }
        [DataMember]
        public int iValor { get; set; }
        [DataMember]
        public DateTime dValor { get; set; }
        [DataMember]
        public float fValor { get; set; }
        [DataMember]
        public string sUnidad { get; set; }

        public int uConfiguracion()
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@ID", ID));
            oP.Add(new SqlParameter("@FVALOR", iValor));
            return Convert.ToInt32(oSql.Escalar("EXI_U_CONFIGURACION", oP));
        }

        public List<Configuracion> rConfiguracion()
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@ID", ID));
            return oSql.TablaParametro<Configuracion>("EXI_R_CONFIGURACION", oP);
        }
        //2022
        public string ListarIndicadores()
        {
            return new sql().TablaJSON("SIMIH_MANTENIMIENTOINDICADOR_R_LISTARINDICADORES");
        }
        //2022
        public int ModificarIndicador(int iId, int fValor)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@iId", iId));
            oP.Add(new SqlParameter("@fValor", fValor));
            return Convert.ToInt32(oSql.Escalar("SIMIH_MANTENIMIENTOINDICADOR_U_MODIFICARINDICADOR", oP));
        }
        //2022
        public string ListarDiasConfirmacionAutomatica()
        {
            return new sql().TablaJSON("SIMIH_MANTENIMIENTODIASCONFIRMACION_R_DIASCONFIRMACION");
        }


    }
}
