using Interna.Core;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Runtime.Serialization;

namespace Interna.Entity
{
    [Serializable]
    [DataContract]
    public class Asistencia : Core.Entity
    {
        //2022
        public string RegistrarIngreso(string dni)
        {
            sql oSql = new sql();
            List<SqlParameter> lP = new List<SqlParameter>();
            lP.Add(new SqlParameter("@DNI", dni));
            return oSql.TablaParametroJSON("asis.SP_REGISTRAR_INGRESO", lP);
        }
        //2022
        public string RegistrarSalida(string dni)
        {
            sql oSql = new sql();
            List<SqlParameter> lP = new List<SqlParameter>();
            lP.Add(new SqlParameter("@DNI", dni));
            return oSql.TablaParametroJSON("asis.SP_REGISTRAR_SALIDA", lP);
        }
        //2022
        public string ReporteAsistencia(int area_id, int empleado_id, DateTime fecha_inicio, DateTime fecha_final)
        {
            sql oSql = new sql();
            List<SqlParameter> lP = new List<SqlParameter>();
            lP.Add(new SqlParameter("@AREA_ID", area_id));
            lP.Add(new SqlParameter("@EMPLEADO_ID", empleado_id));
            lP.Add(new SqlParameter("@FECHA_INICIO", fecha_inicio));
            lP.Add(new SqlParameter("@FECHA_FINAL", fecha_final));
            return oSql.TablaParametroJSON("asis.SP_REPORTE_ASISTENCIA", lP);
        }
        //2022
        public string ListarArea()
        {
            sql oSql = new sql();
            return oSql.TablaJSON("asis.SP_LISTAR_AREA");
        }
        //2022
        public string ListarEmpleado(int area_id)
        {
            if (area_id == 0) return "[]";
            sql oSql = new sql();
            List<SqlParameter> lP = new List<SqlParameter>();
            lP.Add(new SqlParameter("@AREA_ID", area_id));
            return oSql.TablaParametroJSON("asis.SP_LISTAR_EMPLEADO", lP);
        }
        //2022
        public string ListarRegistroAsistenciaDiarioPorArea(int area_id, DateTime fecha)
        {
            sql oSql = new sql();
            List<SqlParameter> lP = new List<SqlParameter>();
            lP.Add(new SqlParameter("@AREA_ID", area_id));
            lP.Add(new SqlParameter("@FECHA_ASISTENCIA", fecha));
            return oSql.TablaParametroJSON("asis.SP_LISTAR_REGISTRO_ASISTENCIA_DIARIO_POR_AREA", lP);
        }
        //2022
        public string ListarAreaAsignada(int usuario_id)
        {
            sql oSql = new sql();
            List<SqlParameter> lP = new List<SqlParameter>();
            lP.Add(new SqlParameter("@ID_USUARIO", usuario_id));
            return oSql.TablaParametroJSON("asis.SP_LISTAR_AREA_ASIGNADAS", lP);
        }
        //2022
        public int ListarPerfilUsuario(int usuario_id)
        {
            sql oSql = new sql();
            List<SqlParameter> lP = new List<SqlParameter>();
            lP.Add(new SqlParameter("@USUARIO_ID", usuario_id));
            return Convert.ToInt32(oSql.Escalar("asis.SP_PERFIL_USUARIO_ASISTENCIA", lP));
        }
        //2022
        public string ListarEstadoAsistencia()
        {
            sql oSql = new sql();
            return oSql.TablaJSON("asis.SP_LISTAR_ESTADO");
        }
        //2022
        public int ModificarAsistencia(int asistencia_id, int ubicacion_id, int estado_id, string observacion)
        {
            sql oSql = new sql();
            List<SqlParameter> lP = new List<SqlParameter>();
            lP.Add(new SqlParameter("@ID", asistencia_id));
            lP.Add(new SqlParameter("@UBICACION_ID", ubicacion_id));
            lP.Add(new SqlParameter("@ESTADO_ID", estado_id));
            lP.Add(new SqlParameter("@OBSERVACION", observacion));
            return Convert.ToInt32(oSql.Escalar("asis.SP_MODIFICAR_ASISTENCIA", lP));

        }
        //2022
        public int RegistrarAsistencia(int colaborador_id, DateTime fecha_ingreso, int ubicacion_id, int estado_id, string observacion)
        {
            sql oSql = new sql();
            List<SqlParameter> lP = new List<SqlParameter>();
            lP.Add(new SqlParameter("@COLABORADOR_ID", colaborador_id));
            lP.Add(new SqlParameter("@FECHA_INGRESO", fecha_ingreso));
            lP.Add(new SqlParameter("@UBICACION_ID", ubicacion_id));
            lP.Add(new SqlParameter("@ESTADO_ID", estado_id));
            lP.Add(new SqlParameter("@OBSERVACION", observacion));
            return Convert.ToInt32(oSql.Escalar("asis.SP_REGISTRAR_ASISTENCIA", lP));

        }
        //2022
        public string ListarEmpleadosMantenimiento()
        {
            sql oSql = new sql();
            return oSql.TablaJSON("asis.SP_LISTAR_EMPLEADOS_MANTENIMIENTO");
        }
        //2022
        public int RegistrarEmpleado(string Nombres, string ApellidoPaterno, string ApellidoMaterno, string Dni, TimeSpan HoraIngreso, int AreaId)
        {
            sql oSql = new sql();
            List<SqlParameter> lP = new List<SqlParameter>();
            lP.Add(new SqlParameter("@NOMBRES", Nombres));
            lP.Add(new SqlParameter("@APELLIDO_PATERNO", ApellidoPaterno));
            lP.Add(new SqlParameter("@APELLIDO_MATERNO", ApellidoMaterno));
            lP.Add(new SqlParameter("@DNI", Dni));
            lP.Add(new SqlParameter("@HORA_INGRESO", HoraIngreso));
            lP.Add(new SqlParameter("@AREA_ID", AreaId));
            return Convert.ToInt32(oSql.Escalar("asis.SP_REGISTRAR_EMPLEADO", lP));
        }
        //2022
        public int ActualizarEmpleado(int Id, string Nombres, string ApellidoPaterno, string ApellidoMaterno, string Dni, TimeSpan HoraIngreso, int AreaId, int EstadoId)
        {
            sql oSql = new sql();
            List<SqlParameter> lP = new List<SqlParameter>();
            lP.Add(new SqlParameter("@ID", Id));
            lP.Add(new SqlParameter("@NOMBRES", Nombres));
            lP.Add(new SqlParameter("@APELLIDO_PATERNO", ApellidoPaterno));
            lP.Add(new SqlParameter("@APELLIDO_MATERNO", ApellidoMaterno));
            lP.Add(new SqlParameter("@DNI", Dni));
            lP.Add(new SqlParameter("@HORA_INGRESO", HoraIngreso));
            lP.Add(new SqlParameter("@AREA_ID", AreaId));
            lP.Add(new SqlParameter("@ESTADO_ID", EstadoId));
            return Convert.ToInt32(oSql.Escalar("asis.SP_ACTUALIZAR_EMPLEADO", lP));
        }
        //2022
        public int EliminarEmpleado(int Id)
        {
            sql oSql = new sql();
            List<SqlParameter> lP = new List<SqlParameter>();
            lP.Add(new SqlParameter("@ID", Id));
            return Convert.ToInt32(oSql.Escalar("asis.SP_ELIMINAR_EMPLEADO", lP));
        }
        //2022
        public string ListarUsuariosPerfil()
        {
            sql oSql = new sql();
            return oSql.TablaJSON("asis.SP_LISTAR_USUARIOS_PERFIL");
        }

    }
}
