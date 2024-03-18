using Interna.Core;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Runtime.Serialization;

namespace Interna.Entity
{
    [Serializable]
    [DataContract]
    public class TokenUsuario : Core.Entity
    {
        [DataMember]
        public string token { get; set; }
        [DataMember]
        public int Estado { get; set; }
        //2022
        public int RegistrarTokenUsuario(string token, int IdUsuario)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@token", token));
            oP.Add(new SqlParameter("@idUsuario", IdUsuario));
            return Convert.ToInt32(oSql.Escalar("SIMIH_C_REGISTRAR_TOKEN_USUARIO", oP));
        }
        //2022
        public TokenUsuario VerificarTokenUsuario(string token)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@token", token));
            TokenUsuario tokenUsuario = oSql.TablaTop<TokenUsuario>("SIMIH_R_VERIFICAR_TOKEN_USUARIO", oP);
            return tokenUsuario;
        }
        //2022
        public int ActualizarTokenUsuario(int IdUsuario)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@idUsuario", IdUsuario));
            return Convert.ToInt32(oSql.Escalar("SIMIH_U_ACTUALIZAR_TOKEN_USUARIO", oP));
        }
        //2022
        public int RegistrarTokenPorValidar(string token)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@token", token));
            return Convert.ToInt32(oSql.Escalar("SIMIH_C_REGISTRAR_TOKEN_VALIDAR", oP));
        }
    }
}
