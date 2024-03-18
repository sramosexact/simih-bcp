using Interna.Core;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Runtime.Serialization;

namespace Interna.Entity
{
    [Serializable]
    [DataContract]
    public class Turno : Core.Entity, Interfaces.ITurno
    {
        #region Propiedades
        [DataMember]
        public Int16 iIdTurno { get; set; }
        [DataMember]
        public string sDescripcionTurno { get; set; }

        public string listaAgencias { get; set; }

        [DataMember]
        public List<Agencia> AgenciasAsociadas { get; set; }

        #endregion

        #region Metodos
        //2022
        public string ListarTurnos()
        {
            sql oSql = new sql();
            return oSql.TablaJSON("SIMIH_ENTREGAAGENCIA_R_LISTARTURNOS");
        }

        public string CrearTurno()
        {
            List<SqlParameter> lp = new List<SqlParameter>();
            lp.Add(new SqlParameter("@DESCRIPCION", sDescripcionTurno));
            lp.Add(new SqlParameter("@AGENCIAS", listaAgencias));
            return new sql().TablaParametroJSON("PC_MANTENIMIENTOTURNO_C_CREARTURNO", lp);
        }

        #endregion
    }
}
