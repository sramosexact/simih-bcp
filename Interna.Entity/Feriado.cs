using Interna.Core;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Runtime.Serialization;

namespace Interna.Entity
{
    [Serializable]
    [DataContract]
    public class Feriado : Core.Entity
    {
        #region Propiedades

        [DataMember]
        public int iIdFeriado { get; set; }
        [DataMember]
        public string sDescripcionFeriado { get; set; }

        public DateTime dFechaFeriado { get; set; }

        public DateTime dFechaRegistro { get; set; }

        public string _fechaFeriadoJson { get; set; }
        public string _fechaRegistroJson { get; set; }

        [DataMember]
        public string dFechaFeriadoJson
        {
            get { return _fechaFeriadoJson; }
            set
            {
                dFechaFeriado = DateTime.Parse(value);
                _fechaFeriadoJson = value;
            }
        }
        [DataMember]
        public string dFechaRegistroJson
        {
            get { return _fechaRegistroJson; }
            set
            {
                dFechaRegistro = DateTime.Parse(value);
                _fechaRegistroJson = value;
            }
        }





        [DataMember]
        public byte iIdRegion { get; set; }
        [DataMember]
        public int iIdUsuario { get; set; }
        [DataMember]
        public byte iIdTipoFeriado { get; set; }
        [DataMember]
        public string sDescripcionRegion { get; set; }
        [DataMember]
        public string sNombreUsuario { get; set; }

        #endregion

        #region Metodos

        public Feriado() { }

        public Feriado(int iIdFeriado)
        {
            this.iIdFeriado = iIdFeriado;
        }

        public Feriado(string sDescripcionFeriado, DateTime dFechaFeriado, int iIdUsuario, byte iIdTipoFeriado)
        {
            this.sDescripcionFeriado = sDescripcionFeriado;
            this.dFechaFeriado = dFechaFeriado;
            this.iIdUsuario = iIdUsuario;
            this.iIdTipoFeriado = iIdTipoFeriado;
        }
        //2022
        public string ListarFeriados(int iIdTipoUsuario, int iIdTipoExpedicion)
        {
            sql oSql = new sql();
            List<SqlParameter> lP = new List<SqlParameter>();
            lP.Add(new SqlParameter("@iIdTipoUsuario", iIdTipoUsuario));
            lP.Add(new SqlParameter("@iIdTipoExpedicion", iIdTipoExpedicion));
            return oSql.TablaParametroJSON("SIMIH_MANTENIMIENTOFERIADO_R_FERIADO", lP);

        }
        //2022
        public int IngresarFeriado()
        {
            sql oSql = new sql();
            List<SqlParameter> lP = new List<SqlParameter>();
            lP.Add(new SqlParameter("@iIdUsuario", iIdUsuario));
            lP.Add(new SqlParameter("@dFechaFeriado", dFechaFeriado));
            lP.Add(new SqlParameter("@iIdTipoFeriado", iIdTipoFeriado));
            lP.Add(new SqlParameter("@sDescripcion", sDescripcionFeriado));
            return Convert.ToInt32(oSql.Escalar("SIMIH_MANTENIMIENTOFERIADO_REGISTRAR_FERIADO", lP));
        }
        //2022
        public int EliminarFeriado()
        {
            sql oSql = new sql();
            List<SqlParameter> lP = new List<SqlParameter>();
            lP.Add(new SqlParameter("@iIdFeriado", iIdFeriado));
            return Convert.ToInt32(oSql.Escalar("SIMIH_MANTENIMIENTOFERIADO_D_FERIADO", lP));
        }



        #endregion
    }
}
