using Interna.Core;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

//using Microsoft.Office.Interop.Excel;

namespace Interna.Entity
{
    [Serializable]
    public class Mensaje : Interna.Core.Entity
    {
        [Column(Name = "iId")]
        public int IdMensaje { get; set; }

        [Column(Name = "sTexto")]
        public string Texto { get; set; }

        [Column(Name = "sIpOrigen")]
        public string IpOrigen { get; set; }

        [Column(Name = "sIpDestino")]
        public string IpDestino { get; set; }

        [Column(Name = "iIdUsuario")]
        public int IdUsuario { get; set; }

        [Column(Name = "iImportancia")]
        public int Importancia { get; set; }

        [Column(Name = "iPuerto")]
        public int Puerto { get; set; }

        public DateTime Creado { get; set; }

        public int cLogin()
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();

            oP.Add(new SqlParameter("@IP_ORIGEN", IpOrigen));
            oP.Add(new SqlParameter("@USUARIO", IdUsuario));
            oP.Add(new SqlParameter("@PUERTO", Puerto));

            return (int)oSql.Escalar("EXI_C_MENSAJE_LOGIN", oP);
        }

        public int cLogout()
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();

            oP.Add(new SqlParameter("@IP_ORIGEN", IpOrigen));
            oP.Add(new SqlParameter("@USUARIO", IdUsuario));

            return (int)oSql.Escalar("EXI_C_MENSAJE_LOGOUT", oP);
        }

        public List<Mensaje> rMensaje()
        {
            sql oSql = new sql();
            return oSql.Tabla<Mensaje>("EXI_R_MENSAJE");
        }

        public int cMensaje()
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();

            oP.Add(new SqlParameter("@TEXTO", Texto));
            oP.Add(new SqlParameter("@IP_ORIGEN", IpOrigen));
            oP.Add(new SqlParameter("@IP_DESTINO", IpDestino));
            oP.Add(new SqlParameter("@USUARIO", IdUsuario));
            oP.Add(new SqlParameter("@IMPORTANCIA", Importancia));

            return (int)oSql.Escalar("EXI_C_MENSAJE", oP);
        }

        public int cMensajeActividad()
        {
            sql oSql = new sql();
            return (int)oSql.Escalar("EXI_C_MENSAJE_ACTIVIDAD");
        }

        public int dMensaje()
        {
            sql oSql = new sql();
            return (int)oSql.Escalar("EXI_D_MENSAJE");
        }

        public List<Mensaje> rMensajeConexion()
        {
            sql oSql = new sql();
            return oSql.Tabla<Mensaje>("EXI_R_MENSAJE_CONEXION");
        }

        public int rProcesoMantenimiento()
        {
            sql oSql = new sql();
            return (int)oSql.Escalar("EXI_R_PROCESO_MANTENIMIENTO");
        }
    }
}
