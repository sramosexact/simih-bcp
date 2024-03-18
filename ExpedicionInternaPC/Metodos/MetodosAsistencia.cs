using Interna.Entity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace ExpedicionInternaPC
{
    public static partial class Metodos
    {
        //2022
        public static Registro RegistrarIngreso(string dni)
        {
            try
            {
                string response = Requester.AuthorizationTask(RutaWS.AsistenciaWS + "RegistrarIngreso", new Dictionary<string, object>(){
                    {"dni", dni}
                });

                return JsonConvert.DeserializeObject<List<Registro>>(response)[0];
            }
            catch (InvalidTokenException)
            {
                throw;
            }

        }
        //2022
        public static Registro RegistrarSalida(string dni)
        {
            try
            {
                string response = Requester.AuthorizationTask(RutaWS.AsistenciaWS + "RegistrarSalida", new Dictionary<string, object>(){
                    {"dni", dni}
                });

                return JsonConvert.DeserializeObject<List<Registro>>(response)[0];
            }
            catch (InvalidTokenException)
            {
                throw;
            }
        }

        //2022
        public static List<ReporteAsistencia> ReporteAsistencia(int area_id, int empleado_id, DateTime fecha_inicio, DateTime fecha_final)
        {
            try
            {
                string response = Requester.AuthorizationTask(RutaWS.AsistenciaWS + "ReporteAsistencia", new Dictionary<string, object>(){
                    {"area_id", area_id},
                    {"empleado_id", empleado_id},
                    {"fecha_inicio", fecha_inicio},
                    {"fecha_final", fecha_final}
                });

                return JsonConvert.DeserializeObject<List<ReporteAsistencia>>(response);
            }
            catch (InvalidTokenException)
            {
                throw;
            }
        }
        //2022
        public static List<Area> ListarArea()
        {
            try
            {
                string response = Requester.AuthorizationTask(RutaWS.AsistenciaWS + "ListarArea", null);

                return JsonConvert.DeserializeObject<List<Area>>(response);
            }
            catch (InvalidTokenException)
            {
                throw;
            }
        }
        //2022
        public static List<Empleado> ListarEmpleado(int area_id)
        {
            try
            {
                string response = Requester.AuthorizationTask(RutaWS.AsistenciaWS + "ListarEmpleado", new Dictionary<string, object>(){
                    {"area_id", area_id}
                });

                return JsonConvert.DeserializeObject<List<Empleado>>(response);
            }
            catch (InvalidTokenException)
            {
                throw;
            }
        }

        //2022
        public static List<RegistroAsistencia> ListarRegistroAsistenciaDiarioPorArea(int area_id, DateTime fecha)
        {
            try
            {
                string response = Requester.AuthorizationTask(RutaWS.AsistenciaWS + "ListarRegistroAsistenciaDiarioPorArea", new Dictionary<string, object>(){
                    {"area_id", area_id},
                    {"fecha", fecha}
                });
                return JsonConvert.DeserializeObject<List<RegistroAsistencia>>(response);
            }
            catch (InvalidTokenException)
            {
                throw;
            }
        }
        //2022
        public static List<Area> ListarAreaAsignada(int usuario_id)
        {
            try
            {
                string response = Requester.AuthorizationTask(RutaWS.AsistenciaWS + "ListarAreaAsignada", new Dictionary<string, object>(){
                    {"usuario_id", usuario_id}
                });

                return JsonConvert.DeserializeObject<List<Area>>(response);
            }
            catch (InvalidTokenException)
            {
                throw;
            }
        }
        //2022
        public static int ListarPerfilUsuarioAsistencia()
        {
            try
            {
                string response = Requester.AuthorizationTask(RutaWS.AsistenciaWS + "ListarPerfilUsuarioAsistencia", new Dictionary<string, object>(){
                    {"usuario_id", Program.oUsuario.ID}
                });

                return Convert.ToInt32(response);
            }
            catch (InvalidTokenException)
            {
                throw;
            }
        }
        //2022
        public static List<EstadoAsistencia> ListarEstadoAsistencia()
        {
            try
            {
                string response = Requester.AuthorizationTask(RutaWS.AsistenciaWS + "ListarEstadoAsistencia", null);

                return JsonConvert.DeserializeObject<List<EstadoAsistencia>>(response);
            }
            catch (InvalidTokenException)
            {
                throw;
            }
        }
        //2022
        public static int ModificarAsistencia(RegistroAsistencia registroAsistencia)
        {
            try
            {
                string response = Requester.AuthorizationTask(RutaWS.AsistenciaWS + "ModificarAsistencia", new Dictionary<string, object>(){
                    {"asistencia_id", registroAsistencia.Id},
                    {"ubicacion_id", registroAsistencia.UbicacionId},
                    {"estado_id", registroAsistencia.EstadoId},
                    {"observacion", registroAsistencia.Observacion}
                });

                return Convert.ToInt32(response);
            }
            catch (InvalidTokenException)
            {
                throw;
            }
        }
        //2022
        public static int RegistrarAsistencia(RegistroAsistencia registroAsistencia)
        {
            try
            {
                string response = Requester.AuthorizationTask(RutaWS.AsistenciaWS + "RegistrarAsistencia", new Dictionary<string, object>(){
                    {"colaborador_id", registroAsistencia.EmpleadoId},
                    {"fecha_ingreso", registroAsistencia.FechaIngreso},
                    {"ubicacion_id", registroAsistencia.UbicacionId},
                    {"estado_id", registroAsistencia.EstadoId},
                    {"observacion", registroAsistencia.Observacion}
                });

                return Convert.ToInt32(response);
            }
            catch (InvalidTokenException)
            {
                throw;
            }
        }
        //2022
        public static List<Empleado> ListarEmpleadosMantenimiento()
        {
            try
            {
                string response = Requester.AuthorizationTask(RutaWS.AsistenciaWS + "ListarEmpleadosMantenimiento", null);

                return JsonConvert.DeserializeObject<List<Empleado>>(response);
            }
            catch (InvalidTokenException)
            {
                throw;
            }
        }
        //2022
        public static int RegistrarEmpleado(Empleado empleado)
        {
            try
            {
                string response = Requester.AuthorizationTask(RutaWS.AsistenciaWS + "RegistrarEmpleado", new Dictionary<string, object>(){
                    {"Nombres", empleado.Nombres},
                    {"ApellidoPaterno", empleado.ApellidoPaterno},
                    {"ApellidoMaterno", empleado.ApellidoMaterno},
                    {"Dni", empleado.Dni},
                    {"HoraIngreso", empleado.HoraIngreso},
                    {"AreaId", empleado.AreaId},
                });

                return Convert.ToInt32(response);
            }
            catch (InvalidTokenException)
            {
                throw;
            }
        }
        //2022
        public static int ActualizarEmpleado(Empleado empleado)
        {
            try
            {
                string response = Requester.AuthorizationTask(RutaWS.AsistenciaWS + "ActualizarEmpleado", new Dictionary<string, object>(){
                    {"Id", empleado.Id},
                    {"Nombres", empleado.Nombres},
                    {"ApellidoPaterno", empleado.ApellidoPaterno},
                    {"ApellidoMaterno", empleado.ApellidoMaterno},
                    {"Dni", empleado.Dni},
                    {"HoraIngreso", empleado.HoraIngreso},
                    {"AreaId", empleado.AreaId},
                    {"EstadoId", empleado.EstadoId}
                });

                return Convert.ToInt32(response);
            }
            catch (InvalidTokenException)
            {
                throw;
            }
        }
        //2022
        public static int EliminarEmpleado(int Id)
        {
            try
            {
                string response = Requester.AuthorizationTask(RutaWS.AsistenciaWS + "EliminarEmpleado", new Dictionary<string, object>(){
                    {"Id", Id}
                });

                return Convert.ToInt32(response);
            }
            catch (InvalidTokenException)
            {
                throw;
            }
        }
    }
}
