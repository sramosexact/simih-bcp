using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Services;
using Interna.Entity;
using simihWS.Helper;

namespace simihWS
{
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    [System.Web.Script.Services.ScriptService]
    public class AsistenciaWS : System.Web.Services.WebService
    {
        //2022
        [WebMethod]
        public string RegistrarIngreso(string dni)
        {
            Asistencia asistencia = new Asistencia();
            return asistencia.RegistrarIngreso(dni);
        }
        //2022
        [WebMethod]
        public string RegistrarSalida(string dni)
        {
            Asistencia asistencia = new Asistencia();
            return asistencia.RegistrarSalida(dni);
        }
        //2022
        [WebMethod]
        public string ReporteAsistencia(int area_id, int empleado_id, DateTime fecha_inicio, DateTime fecha_final)
        {
            Asistencia asistencia = new Asistencia();
            return asistencia.ReporteAsistencia(area_id, empleado_id, fecha_inicio, fecha_final);
        }
        //2022
        [WebMethod]
        public string ListarArea()
        {
            Asistencia asistencia = new Asistencia();
            return asistencia.ListarArea();
        }
        //2022
        [WebMethod]
        public string ListarEmpleado(int area_id)
        {
            Asistencia asistencia = new Asistencia();
            return asistencia.ListarEmpleado(area_id);
        }
        //2022
        [WebMethod]
        public string ListarRegistroAsistenciaDiarioPorArea(int area_id, DateTime fecha)
        {
            Asistencia asistencia = new Asistencia();
            return asistencia.ListarRegistroAsistenciaDiarioPorArea(area_id, fecha);
        }
        //2022
        [WebMethod]
        public string ListarAreaAsignada(int usuario_id)
        {
            Asistencia asistencia = new Asistencia();
            return asistencia.ListarAreaAsignada(usuario_id);
        }
        //2022
        [WebMethod]
        public int ListarPerfilUsuarioAsistencia(int usuario_id)
        {
            Asistencia asistencia = new Asistencia();
            return asistencia.ListarPerfilUsuario(usuario_id);
        }
        //2022
        [WebMethod]
        public string ListarEstadoAsistencia()
        {
            Asistencia asistencia = new Asistencia();
            return asistencia.ListarEstadoAsistencia();
        }
        //2022
        [WebMethod]
        public int ModificarAsistencia(int asistencia_id, int ubicacion_id, int estado_id, string observacion)
        {
            Asistencia asistencia = new Asistencia();
            return asistencia.ModificarAsistencia(asistencia_id, ubicacion_id, estado_id, observacion);
        }

        //2022
        [WebMethod]
        public int RegistrarAsistencia(int colaborador_id, DateTime fecha_ingreso, int ubicacion_id, int estado_id, string observacion)
        {
            Asistencia asistencia = new Asistencia();
            return asistencia.RegistrarAsistencia(colaborador_id, fecha_ingreso, ubicacion_id, estado_id, observacion);
        }
        //2022
        [WebMethod]
        public string ListarEmpleadosMantenimiento()
        {
            Asistencia asistencia = new Asistencia();
            return asistencia.ListarEmpleadosMantenimiento();
        }
        //2022
        [WebMethod]
        public int RegistrarEmpleado(string Nombres, string ApellidoPaterno, string ApellidoMaterno, string Dni, TimeSpan HoraIngreso, int AreaId)
        {
            Asistencia asistencia = new Asistencia();
            return asistencia.RegistrarEmpleado(Nombres, ApellidoPaterno, ApellidoMaterno, Dni, HoraIngreso, AreaId);
        }
        //2022
        [WebMethod]
        public int ActualizarEmpleado(int Id, string Nombres, string ApellidoPaterno, string ApellidoMaterno, string Dni, TimeSpan HoraIngreso, int AreaId, int EstadoId)
        {
            Asistencia asistencia = new Asistencia();
            return asistencia.ActualizarEmpleado(Id, Nombres, ApellidoPaterno, ApellidoMaterno, Dni, HoraIngreso, AreaId, EstadoId);
        }
        //2022
        [WebMethod]
        public int EliminarEmpleado(int Id)
        {
            Asistencia asistencia = new Asistencia();
            return asistencia.EliminarEmpleado(Id);
        }
        //2022
        [WebMethod]
        public string ListarUsuariosPerfil()
        {
            Asistencia asistencia = new Asistencia();
            return asistencia.ListarUsuariosPerfil();
        }
    }
}
