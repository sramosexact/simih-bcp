using Interna.Entity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;


namespace ExpedicionInternaPC
{
    public static partial class Metodos
    {
        //2022
        public static List<Horario> ListarHorariosSedesAsignadas()
        {
            try
            {
                string response = Requester.AuthorizationTask(RutaWS.RecorridoPisosWS + "ListarHorariosSedesAsignadas", null);

                return JsonConvert.DeserializeObject<List<Horario>>(response);
            }
            catch (InvalidTokenException)
            {
                throw;
            }
        }

        //2022
        public static Registro RegistrarInicioRecorrido(Horario horario, string dni)
        {
            try
            {
                string response = Requester.AuthorizationTask(RutaWS.RecorridoPisosWS + "RegistrarInicioRecorrido", new Dictionary<string, object>(){
                    {"horario_id", horario.Id},
                    {"dni", dni }
                });

                return JsonConvert.DeserializeObject<List<Registro>>(response)[0];
            }
            catch (InvalidTokenException)
            {
                throw;
            }
        }

        //2022
        public static Registro RegistrarRetornoRecorrido(Horario horario, string dni)
        {
            try
            {
                string response = Requester.AuthorizationTask(RutaWS.RecorridoPisosWS + "RegistrarRetornoRecorrido", new Dictionary<string, object>(){
                    {"horario_id", horario.Id},
                    {"dni", dni }
                });

                return JsonConvert.DeserializeObject<List<Registro>>(response)[0];
            }
            catch (InvalidTokenException)
            {
                throw;
            }
        }

        //2022
        public static List<ReporteRecorridoPisos> ReporteRecorridoPisos(int sede_id, int colaborador_id, DateTime fecha_inicio, DateTime fecha_final)
        {
            try
            {
                string response = Requester.AuthorizationTask(RutaWS.RecorridoPisosWS + "ReporteRecorridoPisos", new Dictionary<string, object>(){
                    {"sede_id", sede_id},
                    {"colaborador_id", colaborador_id},
                    {"fecha_inicio", fecha_inicio},
                    {"fecha_final", fecha_final}
                });

                return JsonConvert.DeserializeObject<List<ReporteRecorridoPisos>>(response);
            }
            catch (InvalidTokenException)
            {
                throw;
            }
        }

        //2022
        public static List<Sede> ListarSede()
        {
            try
            {
                string response = Requester.AuthorizationTask(RutaWS.RecorridoPisosWS + "ListarSede", null);

                return JsonConvert.DeserializeObject<List<Sede>>(response);
            }
            catch (InvalidTokenException)
            {
                throw;
            }
        }
        //2022
        public static List<ColaboradorPisos> ListarColaboradorPisos(int sede_id)
        {
            try
            {
                string response = Requester.AuthorizationTask(RutaWS.RecorridoPisosWS + "ListarColaboradorPisos", new Dictionary<string, object>(){
                    {"sede_id", sede_id}
                });

                return JsonConvert.DeserializeObject<List<ColaboradorPisos>>(response);
            }
            catch (InvalidTokenException)
            {
                throw;
            }
        }

        //2022
        public static List<ColaboradorPisos> ListarColaboradoresPisoMantenimiento()
        {
            try
            {
                string response = Requester.AuthorizationTask(RutaWS.RecorridoPisosWS + "ListarColaboradoresPisoMantenimiento", null);

                return JsonConvert.DeserializeObject<List<ColaboradorPisos>>(response);
            }
            catch (InvalidTokenException)
            {
                throw;
            }
        }
        //2022
        public static int RegistrarColaboradorPisos(ColaboradorPisos colaboradorPisos)
        {
            try
            {
                string response = Requester.AuthorizationTask(RutaWS.RecorridoPisosWS + "RegistrarColaboradorPisos", new Dictionary<string, object>(){
                    {"Nombres", colaboradorPisos.Nombres},
                    {"ApellidoPaterno", colaboradorPisos.ApellidoPaterno},
                    {"ApellidoMaterno", colaboradorPisos.ApellidoMaterno},
                    {"Dni", colaboradorPisos.Dni},
                    {"SedeId", colaboradorPisos.SedeId},
                });

                return Convert.ToInt32(response);
            }
            catch (InvalidTokenException)
            {
                throw;
            }
        }
        //2022
        public static int ActualizarColaboradorPisos(ColaboradorPisos colaboradorPisos)
        {
            try
            {
                string response = Requester.AuthorizationTask(RutaWS.RecorridoPisosWS + "ActualizarColaboradorPisos", new Dictionary<string, object>(){
                    {"Id", colaboradorPisos.Id},
                    {"Nombres", colaboradorPisos.Nombres},
                    {"ApellidoPaterno", colaboradorPisos.ApellidoPaterno},
                    {"ApellidoMaterno", colaboradorPisos.ApellidoMaterno},
                    {"Dni", colaboradorPisos.Dni},
                    {"SedeId", colaboradorPisos.SedeId},
                    {"Activo", colaboradorPisos.Activo}
                });

                return Convert.ToInt32(response);
            }
            catch (InvalidTokenException)
            {
                throw;
            }
        }

        //2022
        public static List<Sede> ListarSedesAsignadas(Usuario usuario)
        {
            try
            {
                string response = Requester.AuthorizationTask(RutaWS.RecorridoPisosWS + "ListarSedesAsignadas", new Dictionary<string, object>(){
                    {"UsuarioId", usuario.ID}
                });

                return JsonConvert.DeserializeObject<List<Sede>>(response);
            }
            catch (InvalidTokenException)
            {
                throw;
            }
        }

    }
}
