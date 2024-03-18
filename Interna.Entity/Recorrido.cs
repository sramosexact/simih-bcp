using Interna.Core;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Runtime.Serialization;

namespace Interna.Entity
{
    [Serializable]
    [DataContract]
    public class Recorrido : Interna.Core.Entity
    {
        public String Nombre { get; set; }
        public int IdUsuario { get; set; }
        public int IdMensajeria { get; set; }
        public int IdEntrega { get; set; }
        public String IdRecurso { get; set; }
        public int Tipo { get; set; }
        public String Descripcion { get; set; }
        public int IdExpedicion { get; set; }

        /*Incorporando horario de recorrido 24/11/2015 Benji Villarreal*/

        [DataMember]
        public int IdRecorrido { set; get; }

        [DataMember]
        public string Nro { set; get; }

        private String HoraInicioRecorridoJson { set; get; }
        public DateTime _HoraInicioRecorrido { set; get; }

        [DataMember]
        public string HoraInicioRecorrido
        {
            set
            {
                _HoraInicioRecorrido = DateTime.Parse(value);
                HoraInicioRecorridoJson = value;
            }
            get
            {
                return HoraInicioRecorridoJson;
            }
        }

        private String HoraFinRecorridoJson { set; get; }
        public DateTime _HoraFinRecorrido { set; get; }
        [DataMember]
        public string HoraFinRecorrido
        {

            set
            {
                _HoraFinRecorrido = DateTime.Parse(value);
                HoraFinRecorridoJson = value;
            }
            get
            {
                return HoraFinRecorridoJson;
            }
        }

        [DataMember]
        public string TipoRecorrido { set; get; }

        /*Termino*/

        public DateTime inicio { get; set; }
        public DateTime fin { get; set; }
        public String Recurrenceinfo { get; set; }
        public String Recurrencepattern { get; set; }
        public int RecurrenceIndex { get; set; }
        public int Rango { get; set; }
        public DateTime Ffinrec { get; set; }

        public Recorrido()
        {
            inicio = DateTime.Now;
            fin = DateTime.Now;
        }

        public int cRecorrido()
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@NOMBRE", Nombre));
            oP.Add(new SqlParameter("@IDUSUARIO", IdUsuario));
            oP.Add(new SqlParameter("@IDEXPEDICION", IdExpedicion));
            oP.Add(new SqlParameter("@IDMENSAJERIA", IdMensajeria));
            oP.Add(new SqlParameter("@IDENTREGA", IdEntrega));
            oP.Add(new SqlParameter("@IDRECURSO", IdRecurso));  // llave
            if (inicio.Year < 1700) inicio = DateTime.Now;
            if (fin.Year < 1700) fin = DateTime.Now;
            oP.Add(new SqlParameter("@INICIO", inicio));
            oP.Add(new SqlParameter("@FIN", fin));
            oP.Add(new SqlParameter("@RECURRENCEINFO", Recurrenceinfo));
            oP.Add(new SqlParameter("@RECURRENCEPATTERN", Recurrencepattern));
            oP.Add(new SqlParameter("@TIPO", Tipo));
            oP.Add(new SqlParameter("@DESCRIPCION", Descripcion));
            oP.Add(new SqlParameter("@RECURRENCEINDEX", RecurrenceIndex));
            oP.Add(new SqlParameter("@RANGO", Rango));
            oP.Add(new SqlParameter("@FFINREC", Ffinrec));

            try
            {
                return (int)oSql.Escalar("EXI_C_RECORRIDO", oP);
            }
            catch (Exception e) { }
            return 0;
        }

        public int dRecorrido()
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@IDUSUARIO", IdUsuario));
            oP.Add(new SqlParameter("@TIPO", Tipo));
            oP.Add(new SqlParameter("@IDRECURSO", IdRecurso));
            oP.Add(new SqlParameter("@RECURRENCEINDEX", RecurrenceIndex));
            return (int)oSql.Exec("EXI_D_RECORRIDO", oP);
        }


        public int uRecorrido()
        {
            sql oSql = new sql();
            if (inicio.Year < 1700) inicio = DateTime.Now;
            if (fin.Year < 1700) fin = DateTime.Now;
            if (Ffinrec.Year < 1700) Ffinrec = DateTime.Now;

            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@NOMBRE", Nombre));
            oP.Add(new SqlParameter("@IDUSUARIO", IdUsuario));
            oP.Add(new SqlParameter("@IDMENSAJERIA", IdMensajeria));
            oP.Add(new SqlParameter("@IDENTREGA", IdEntrega));
            oP.Add(new SqlParameter("@DESCRIPCION", Descripcion));
            oP.Add(new SqlParameter("@IDRECURSO", IdRecurso)); // llave
            oP.Add(new SqlParameter("@INICIO", inicio));
            oP.Add(new SqlParameter("@FIN", fin));
            oP.Add(new SqlParameter("@RECURRENCEINFO", Recurrenceinfo));
            oP.Add(new SqlParameter("@RECURRENCEPATTERN", Recurrencepattern));
            oP.Add(new SqlParameter("@TIPO", Tipo));
            oP.Add(new SqlParameter("@RECURRENCEINDEX", RecurrenceIndex));
            oP.Add(new SqlParameter("@RANGO", Rango));
            oP.Add(new SqlParameter("@FFINREC", Ffinrec));

            try
            {
                return (int)oSql.Escalar("EXI_U_RECORRIDO", oP);
            }
            catch (Exception)
            {
            }
            return 0;
        }

        public List<Recorrido> rRecorrido(DateTime dtini, DateTime dtfin)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@IDEXPEDICION", IdExpedicion));
            oP.Add(new SqlParameter("@INICIO", dtini));
            oP.Add(new SqlParameter("@FIN", dtfin));
            return oSql.TablaParametro<Recorrido>("EXI_R_RECORRIDO", oP);
        }
        public String rObtenerRecorridos(int IdExpedicion)
        {
            sql oSql = new sql();
            List<SqlParameter> Op = new List<SqlParameter>();
            Op.Add(new SqlParameter("@IdExpedicion", @IdExpedicion));
            return oSql.TablaParametroJSON("PEXI_R_PLAN_RECORRIDO", Op);
        }
    }
}
