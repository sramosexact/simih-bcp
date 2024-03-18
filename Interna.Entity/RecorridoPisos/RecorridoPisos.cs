using Interna.Core;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Runtime.Serialization;

namespace Interna.Entity
{
    [Serializable]
    [DataContract]
    public class RecorridoPisos
    {
        //2022
        public string ListarHorariosSedesAsignadas(string upn)
        {

            sql oSql = new sql();
            List<SqlParameter> lP = new List<SqlParameter>();
            lP.Add(new SqlParameter("@UPN", upn));
            return oSql.TablaParametroJSON("rec.SP_LISTAR_HORARIOS_SEDES_ASIGNADAS", lP);
        }
        //2022
        public string RegistrarInicioRecorrido(int horario_id, string dni)
        {
            sql oSql = new sql();
            List<SqlParameter> lP = new List<SqlParameter>();
            lP.Add(new SqlParameter("@HORARIO_ID", horario_id));
            lP.Add(new SqlParameter("@DNI", dni));
            return oSql.TablaParametroJSON("rec.SP_REGISTRAR_INICIO_RECORRIDO", lP);
        }
        //2022
        public string RegistrarRetornoRecorrido(int horario_id, string dni)
        {
            sql oSql = new sql();
            List<SqlParameter> lP = new List<SqlParameter>();
            lP.Add(new SqlParameter("@HORARIO_ID", horario_id));
            lP.Add(new SqlParameter("@DNI", dni));
            return oSql.TablaParametroJSON("rec.SP_REGISTRAR_RETORNO_RECORRIDO", lP);
        }

        //2022
        public string ReporteRecorridoPisos(int sede_id, int colaborador_id, DateTime fecha_inicio, DateTime fecha_final)
        {
            sql oSql = new sql();
            List<SqlParameter> lP = new List<SqlParameter>();
            lP.Add(new SqlParameter("@SEDE_ID", sede_id));
            lP.Add(new SqlParameter("@COLABORADOR_ID", colaborador_id));
            lP.Add(new SqlParameter("@FECHA_INICIO", fecha_inicio));
            lP.Add(new SqlParameter("@FECHA_FINAL", fecha_final));
            return oSql.TablaParametroJSON("rec.SP_REPORTE_RECORRIDO_PISOS", lP);
        }
        //2022
        public string ListarSede()
        {
            sql oSql = new sql();
            return oSql.TablaJSON("rec.SP_LISTAR_SEDE");
        }
        //2022
        public string ListarColaboradorPisos(int area_id)
        {
            if (area_id == 0) return "[]";
            sql oSql = new sql();
            List<SqlParameter> lP = new List<SqlParameter>();
            lP.Add(new SqlParameter("@SEDE_ID", area_id));
            return oSql.TablaParametroJSON("rec.SP_LISTAR_COLABORADOR", lP);
        }
        //2022
        public string ListarColaboradoresPisoMantenimiento()
        {
            sql oSql = new sql();
            return oSql.TablaJSON("rec.SP_LISTAR_COLABORADORES_PISO_MANTENIMIENTO");
        }
        //2022
        public int RegistrarColaboradorPisos(string Nombres, string ApellidoPaterno, string ApellidoMaterno, string Dni, int SedeId)
        {
            sql oSql = new sql();
            List<SqlParameter> lP = new List<SqlParameter>();
            lP.Add(new SqlParameter("@NOMBRES", Nombres));
            lP.Add(new SqlParameter("@APELLIDO_PATERNO", ApellidoPaterno));
            lP.Add(new SqlParameter("@APELLIDO_MATERNO", ApellidoMaterno));
            lP.Add(new SqlParameter("@DNI", Dni));
            lP.Add(new SqlParameter("@SEDE_ID", SedeId));
            return Convert.ToInt32(oSql.Escalar("rec.SP_REGISTRAR_COLABORADOR_PISOS", lP));
        }
        //2022
        public int ActualizarColaboradorPisos(int Id, string Nombres, string ApellidoPaterno, string ApellidoMaterno, string Dni, int SedeId, bool Activo)
        {
            sql oSql = new sql();
            List<SqlParameter> lP = new List<SqlParameter>();
            lP.Add(new SqlParameter("@ID", Id));
            lP.Add(new SqlParameter("@NOMBRES", Nombres));
            lP.Add(new SqlParameter("@APELLIDO_PATERNO", ApellidoPaterno));
            lP.Add(new SqlParameter("@APELLIDO_MATERNO", ApellidoMaterno));
            lP.Add(new SqlParameter("@DNI", Dni));
            lP.Add(new SqlParameter("@SEDE_ID", SedeId));
            lP.Add(new SqlParameter("@ACTIVO", Activo));
            return Convert.ToInt32(oSql.Escalar("rec.SP_ACTUALIZAR_COLABORADOR_PISOS", lP));
        }
        //2022
        public string ListarUsuariosPerfil()
        {
            sql oSql = new sql();
            return oSql.TablaJSON("rec.SP_LISTAR_USUARIOS_PERFIL");
        }
        //2022
        public string ListarSedesAsignadas(int UsuarioId)
        {
            sql oSql = new sql();
            List<SqlParameter> lP = new List<SqlParameter>();
            lP.Add(new SqlParameter("@USUARIO_ID", UsuarioId));
            return oSql.TablaParametroJSON("rec.SP_LISTAR_SEDES_ASIGNADAS", lP);
        }

    }
}
