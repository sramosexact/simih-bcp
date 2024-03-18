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
    }
}
