using Interna.Entity;
using simihWS.Helper;
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Services;

namespace simihWS
{
    /*20/12/2016*/
    /// <summary>
    /// Descripción breve de AgenciaWS
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    [System.Web.Script.Services.ScriptService]
    public class AgenciaWS : System.Web.Services.WebService
    {

        [WebMethod]
        public string listarAgenciasPorTurno(short iIdTurno)
        {
            Turno oTurno = new Turno()
            {
                iIdTurno = iIdTurno
            };

            Agencia oAgencia = new Agencia();
            return oAgencia.listarAgenciasPorTurno(oTurno);
        }
        //2022
        [WebMethod]
        public string obtenerAgenciaPorCodigo(string sCodigoAgencia)
        {
            Agencia oAgencia = new Agencia()
            {
                sCodigoAgencia = sCodigoAgencia
            };
            return oAgencia.obtenerAgenciaPorCodigo();
        }
        //2022
        [WebMethod]
        public int crearEnvioAgencias(int IdColaboradorSeleccionado, string xmlLote)
        {
            AccessToken accessToken = new AccessToken(HttpContext.Current);
            List<TipoUsuarioEnum> tipoUsuarios = new List<TipoUsuarioEnum>();
            tipoUsuarios.Add(TipoUsuarioEnum.SIMIH_COLABORADOR);
            tipoUsuarios.Add(TipoUsuarioEnum.SIMIH_SUPERVISOR);

            if (!Helper.Helper.ValidarTipoUsuario(accessToken.GetUpn(), tipoUsuarios))
            {
                HttpContext.Current.Response.StatusCode = 401;
                HttpContext.Current.Response.Headers.Add("Unauthorized", "Basic realm=\"Acceso al sistema SIMIH\", charset=\"UTF-8\"");
                return -1;
            }

            string upn = accessToken.GetUpn();

            Agencia oAgencia = new Agencia();

            return oAgencia.CrearEnvioAgencias(upn, xmlLote, IdColaboradorSeleccionado);
        }

        [WebMethod]
        public string ObtenerListadoAgencia()
        {
            return new Agencia().ObtenerListadoAgencia();
        }

        //2022
        [WebMethod]
        public string ListarAgencias()
        {
            AccessToken accessToken = new AccessToken(HttpContext.Current);
            List<TipoUsuarioEnum> tipoUsuarios = new List<TipoUsuarioEnum>();
            tipoUsuarios.Add(TipoUsuarioEnum.SIMIH_JEFE);
            tipoUsuarios.Add(TipoUsuarioEnum.SIMIH_SUPERVISOR);
            tipoUsuarios.Add(TipoUsuarioEnum.SIMIH_COLABORADOR);

            if (!Helper.Helper.ValidarTipoUsuario(accessToken.GetUpn(), tipoUsuarios))
            {
                HttpContext.Current.Response.StatusCode = 401;
                HttpContext.Current.Response.Headers.Add("Unauthorized", "Basic realm=\"Acceso al sistema SIMIH\", charset=\"UTF-8\"");
                return "";
            }
            Agencia agencia = new Agencia();
            return agencia.ListarAgencias();
        }

        //2022
        [WebMethod]
        public int CrearAgencia(string sCodigoAgencia, string sDescripcion, int iIdGeoDireccion, int iTipo)
        {
            AccessToken accessToken = new AccessToken(HttpContext.Current);
            List<TipoUsuarioEnum> tipoUsuarios = new List<TipoUsuarioEnum>();
            tipoUsuarios.Add(TipoUsuarioEnum.SIMIH_JEFE);
            tipoUsuarios.Add(TipoUsuarioEnum.SIMIH_SUPERVISOR);

            if (!Helper.Helper.ValidarTipoUsuario(accessToken.GetUpn(), tipoUsuarios))
            {
                HttpContext.Current.Response.StatusCode = 401;
                HttpContext.Current.Response.Headers.Add("Unauthorized", "Basic realm=\"Acceso al sistema SIMIH\", charset=\"UTF-8\"");
                return -1;
            }
            Agencia oAgencia = new Agencia()
            {
                sCodigoAgencia = sCodigoAgencia,
                sDescripcion = sDescripcion,
                iIdGeoDireccion = iIdGeoDireccion,
                iTipo = iTipo
            };
            return oAgencia.CrearAgencia();
        }

        //2022
        [WebMethod]
        public int ModificarAgencia(int iIdAgencia, string sDescripcion, int iActivo)
        {
            AccessToken accessToken = new AccessToken(HttpContext.Current);
            List<TipoUsuarioEnum> tipoUsuarios = new List<TipoUsuarioEnum>();
            tipoUsuarios.Add(TipoUsuarioEnum.SIMIH_JEFE);
            tipoUsuarios.Add(TipoUsuarioEnum.SIMIH_SUPERVISOR);

            if (!Helper.Helper.ValidarTipoUsuario(accessToken.GetUpn(), tipoUsuarios))
            {
                HttpContext.Current.Response.StatusCode = 401;
                HttpContext.Current.Response.Headers.Add("Unauthorized", "Basic realm=\"Acceso al sistema SIMIH\", charset=\"UTF-8\"");
                return -1;
            }
            Agencia oAgencia = new Agencia()
            {
                iId = iIdAgencia,
                sDescripcion = sDescripcion,
                iActivo = iActivo
            };

            return oAgencia.ModificarAgencia();
        }

        //2022
        [WebMethod]
        public int CambiarEstadoAgencia(int idAgencia)
        {
            AccessToken accessToken = new AccessToken(HttpContext.Current);
            List<TipoUsuarioEnum> tipoUsuarios = new List<TipoUsuarioEnum>();
            tipoUsuarios.Add(TipoUsuarioEnum.SIMIH_JEFE);
            tipoUsuarios.Add(TipoUsuarioEnum.SIMIH_SUPERVISOR);

            if (!Helper.Helper.ValidarTipoUsuario(accessToken.GetUpn(), tipoUsuarios))
            {
                HttpContext.Current.Response.StatusCode = 401;
                HttpContext.Current.Response.Headers.Add("Unauthorized", "Basic realm=\"Acceso al sistema SIMIH\", charset=\"UTF-8\"");
                return -1;
            }
            Agencia oAgencia = new Agencia()
            {
                iId = idAgencia
            };

            return oAgencia.CambiarEstadoAgencia();
        }

        //2022
        [WebMethod]
        public string ListarAgenciasNoVinculadasTurno(int IdTurno)
        {
            AccessToken accessToken = new AccessToken(HttpContext.Current);
            List<TipoUsuarioEnum> tipoUsuarios = new List<TipoUsuarioEnum>();
            tipoUsuarios.Add(TipoUsuarioEnum.SIMIH_JEFE);
            tipoUsuarios.Add(TipoUsuarioEnum.SIMIH_SUPERVISOR);

            if (!Helper.Helper.ValidarTipoUsuario(accessToken.GetUpn(), tipoUsuarios))
            {
                HttpContext.Current.Response.StatusCode = 401;
                HttpContext.Current.Response.Headers.Add("Unauthorized", "Basic realm=\"Acceso al sistema SIMIH\", charset=\"UTF-8\"");
                return "";
            }
            Agencia agencia = new Agencia()
            {
                IdTurno = IdTurno
            };

            return agencia.ListarAgenciasNoVinculadasTurno();
        }

        //2022
        [WebMethod]
        public string ListarAgenciasVinculadasTurno()
        {
            AccessToken accessToken = new AccessToken(HttpContext.Current);
            List<TipoUsuarioEnum> tipoUsuarios = new List<TipoUsuarioEnum>();
            tipoUsuarios.Add(TipoUsuarioEnum.SIMIH_JEFE);
            tipoUsuarios.Add(TipoUsuarioEnum.SIMIH_SUPERVISOR);

            if (!Helper.Helper.ValidarTipoUsuario(accessToken.GetUpn(), tipoUsuarios))
            {
                HttpContext.Current.Response.StatusCode = 401;
                HttpContext.Current.Response.Headers.Add("Unauthorized", "Basic realm=\"Acceso al sistema SIMIH\", charset=\"UTF-8\"");
                return "";
            }

            return new Agencia().ListarAgenciasVinculadasTurno();
        }

        //2022
        [WebMethod]
        public int VincularAgenciaTurno(int IdTurno, string listaAgencias)
        {
            AccessToken accessToken = new AccessToken(HttpContext.Current);
            List<TipoUsuarioEnum> tipoUsuarios = new List<TipoUsuarioEnum>();
            tipoUsuarios.Add(TipoUsuarioEnum.SIMIH_JEFE);
            tipoUsuarios.Add(TipoUsuarioEnum.SIMIH_SUPERVISOR);

            if (!Helper.Helper.ValidarTipoUsuario(accessToken.GetUpn(), tipoUsuarios))
            {
                HttpContext.Current.Response.StatusCode = 401;
                HttpContext.Current.Response.Headers.Add("Unauthorized", "Basic realm=\"Acceso al sistema SIMIH\", charset=\"UTF-8\"");
                return -1;
            }

            Agencia oAgencia = new Agencia()
            {
                IdTurno = IdTurno,
                sDescripcion = listaAgencias
            };

            return oAgencia.VincularAgenciaTurno();
        }

        //2022
        [WebMethod]
        public int EliminarVinculoAgenciaTurno(int idAgencia, int IdTurno)
        {
            AccessToken accessToken = new AccessToken(HttpContext.Current);
            List<TipoUsuarioEnum> tipoUsuarios = new List<TipoUsuarioEnum>();
            tipoUsuarios.Add(TipoUsuarioEnum.SIMIH_JEFE);
            tipoUsuarios.Add(TipoUsuarioEnum.SIMIH_SUPERVISOR);

            if (!Helper.Helper.ValidarTipoUsuario(accessToken.GetUpn(), tipoUsuarios))
            {
                HttpContext.Current.Response.StatusCode = 401;
                HttpContext.Current.Response.Headers.Add("Unauthorized", "Basic realm=\"Acceso al sistema SIMIH\", charset=\"UTF-8\"");
                return -1;
            }

            Agencia oAgencia = new Agencia()
            {
                iId = idAgencia,
                IdTurno = IdTurno
            };
            return oAgencia.EliminarVinculoAgenciaTurno();
        }

        //2022
        [WebMethod]
        public String listarAgenciasPalomarTurno(short iIdTurno, int idPalomar)
        {
            Agencia oAgencia = new Agencia();
            Turno turno = new Turno()
            {
                iIdTurno = iIdTurno
            };
            Palomar palomar = new Palomar()
            {
                ID = idPalomar
            };
            return oAgencia.listarAgenciasPalomarTurno(turno, palomar);
        }
    }
}
