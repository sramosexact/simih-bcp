using Interna.Core;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Interna.Entity
{
    [Serializable]
    public class Persona : Interna.Core.Entity
    {
        public int IdPersona { get; set; }
        public string Nombre { get; set; }
        public int IdDocumento { get; set; }//60
        public string Documento { get; set; }//DNI
        public string IdCliente { get; set; }//12345678..
        public string CIC { get; set; }
        public int IdDistrito { get; set; }
        public string Distrito { get; set; }
        public string Direccion { get; set; }
        public string Referencia { get; set; }
        public string Telefono { get; set; }
        public DateTime Fecha { get; set; }

        public List<Persona> rDirecciones(int idPersona, int ind)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@IDPERSONA", idPersona));
            oP.Add(new SqlParameter("@INDICE", ind));
            return oSql.TablaParametro<Persona>("EXI_R_DATOSCLIENTE", oP);
        }

        public List<Persona> rTelefonos(int idPersona, int ind)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@IDPERSONA", idPersona));
            oP.Add(new SqlParameter("@INDICE", ind));
            return oSql.TablaParametro<Persona>("EXI_R_DATOSCLIENTE", oP);
        }

        public Persona rDatosPersona(int idPersona, int ind)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@IDPERSONA", idPersona));
            oP.Add(new SqlParameter("@INDICE", ind));
            return oSql.TablaTop<Persona>("EXI_R_DATOSCLIENTE", oP);
        }
    }
}
