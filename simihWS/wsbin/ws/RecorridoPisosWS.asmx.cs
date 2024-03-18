using simihWS.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using Interna.Entity;

namespace simihWS
{
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    [System.Web.Script.Services.ScriptService]
    public class RecorridoPisosWS : System.Web.Services.WebService
    {
        //2022
        [WebMethod]
        public string ListarHorariosSedesAsignadas()
        {
            AccessToken accessToken = new AccessToken(HttpContext.Current);
            string upn = accessToken.GetUpn();

            RecorridoPisos recorridoPisos = new RecorridoPisos();
            return recorridoPisos.ListarHorariosSedesAsignadas(upn);
            
        }
        //2022
        [WebMethod]
        public string RegistrarInicioRecorrido(int horario_id, string dni)
        {
            RecorridoPisos recorridoPisos = new RecorridoPisos();
            return recorridoPisos.RegistrarInicioRecorrido(horario_id, dni);
        }
        //2022
        [WebMethod]
        public string RegistrarRetornoRecorrido(int horario_id, string dni)
        {
            RecorridoPisos recorridoPisos = new RecorridoPisos();
            return recorridoPisos.RegistrarRetornoRecorrido(horario_id, dni);
        }
        //2022
        [WebMethod]
        public string ReporteRecorridoPisos(int sede_id, int colaborador_id, DateTime fecha_inicio, DateTime fecha_final)
        {
            RecorridoPisos recorridoPisos = new RecorridoPisos();
            return recorridoPisos.ReporteRecorridoPisos(sede_id, colaborador_id, fecha_inicio, fecha_final);
        }
        //2022
        [WebMethod]
        public string ListarSede()
        {
            RecorridoPisos recorridoPisos = new RecorridoPisos();
            return recorridoPisos.ListarSede();
        }
        //2022
        [WebMethod]
        public string ListarColaboradorPisos(int sede_id)
        {
            RecorridoPisos recorridoPisos = new RecorridoPisos();
            return recorridoPisos.ListarColaboradorPisos(sede_id);
        }
        //2022
        [WebMethod]
        public string ListarColaboradoresPisoMantenimiento()
        {
            RecorridoPisos recorridoPisos = new RecorridoPisos();
            return recorridoPisos.ListarColaboradoresPisoMantenimiento();
        }
        //2022
        [WebMethod]
        public int RegistrarColaboradorPisos(string Nombres, string ApellidoPaterno, string ApellidoMaterno, string Dni, int SedeId)
        {
            RecorridoPisos recorridoPisos = new RecorridoPisos();
            return recorridoPisos.RegistrarColaboradorPisos(Nombres, ApellidoPaterno, ApellidoMaterno, Dni, SedeId);
        }
        //2022
        [WebMethod]
        public int ActualizarColaboradorPisos(int Id, string Nombres, string ApellidoPaterno, string ApellidoMaterno, string Dni, int SedeId, bool Activo)
        {
            RecorridoPisos recorridoPisos = new RecorridoPisos();
            return recorridoPisos.ActualizarColaboradorPisos(Id, Nombres, ApellidoPaterno, ApellidoMaterno, Dni, SedeId, Activo);
        }
        //2022
        [WebMethod]
        public string ListarUsuariosPerfil()
        {
            RecorridoPisos recorridoPisos = new RecorridoPisos();
            return recorridoPisos.ListarUsuariosPerfil();
        }
        //2022
        [WebMethod]
        public string ListarSedesAsignadas(int UsuarioId)
        {
            RecorridoPisos recorridoPisos = new RecorridoPisos();
            return recorridoPisos.ListarSedesAsignadas(UsuarioId);
        }
    }
}
