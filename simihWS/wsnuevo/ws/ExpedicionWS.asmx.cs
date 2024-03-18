using Interna.Entity;
using simihWS.Helper;
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Services;

namespace simihWS
{
    /// <summary>
    /// Descripción breve de ExpedicionWS
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    [System.Web.Script.Services.ScriptService]
    public class ExpedicionWS : System.Web.Services.WebService
    {

        [WebMethod]
        public void SetRecorrido(Recorrido oO)
        {
            oO.cRecorrido();
        }

        [WebMethod]
        public void deleteRecorrido(Recorrido oO)
        {
            oO.dRecorrido();
        }

        [WebMethod]
        public void updateRecorrido(Recorrido oO)
        {
            oO.uRecorrido();
        }

        [WebMethod]
        public List<Recorrido> GetLista_Plan(int IdExpedicion, DateTime fini, DateTime ffin)
        {
            Recorrido O = new Recorrido();
            O.IdExpedicion = IdExpedicion;
            return O.rRecorrido(fini, ffin);
        }

        [WebMethod]
        public string GetExpedicion_Cliente(int id)
        {
            Expedicion oU = new Expedicion();
            return oU.rListadoExpedicion(id);
        }
        [WebMethod]
        public Expedicion GetGeoExpedicion(int id)
        {
            Expedicion O = new Expedicion();
            return O.rExpedicion(id);
        }


        [WebMethod]
        public List<Expedicion> GetExpedicionLista(Expedicion oO, int RecordIndex, int Width)
        {
            Interna.Entity.Expedicion oU = new Interna.Entity.Expedicion();
            return oU.rListadoExpedicionLista(oO, RecordIndex, Width);
        }

        [WebMethod]
        public int ListaExpedicionCONTAR()
        {
            Expedicion E = new Expedicion();
            return E.ListaExpedicionCONTAR();
        }

        [WebMethod]
        public List<Expedicion> GetExpedicionListaUsuario(Usuario oO)
        {
            Interna.Entity.Expedicion oU = new Interna.Entity.Expedicion();
            return oU.rListadoExpedicionListaUsuario(oO);
        }


        //2022
        [WebMethod]
        public string GetExpedicionListaUsuarioPrueba(int id)
        {
            Expedicion oU = new Expedicion();
            Usuario oO = new Usuario();
            oO.ID = id;
            return oU.rListadoExpedicionListaUsuarioPrueba(oO);
        }


        [WebMethod]
        public int setCuExpedicion(Expedicion oE)
        {
            return oE.cuGrabar(oE);
        }

        [WebMethod]
        public List<Expedicion> GetExpedicionGeoDominio(Expedicion oEX)
        {
            return oEX.rExpedicionGeo();
        }

        //2022
        [WebMethod]
        public string ListarExpedicion()
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

            Expedicion oU = new Expedicion();
            return oU.ListarExpedicion();
        }

        /*Introducido 24/11/2015 zbvm*/
        [WebMethod]
        public String rObtenerRecorridos(int idExpedicion)
        {
            Recorrido re = new Recorrido();
            return re.rObtenerRecorridos(idExpedicion);
        }
        //2022
        [WebMethod]
        public String rListarExpediciones()
        {
            Expedicion ex = new Expedicion();
            return ex.rListarExpediciones();
        }

        //2022
        [WebMethod]
        public int NuevaExpedicion(int ID, int idCalle, int idTipoExpedicion, int IdCliente, string Descripcion, string Prefijo, string Geo)
        {
            AccessToken accessToken = new AccessToken(HttpContext.Current);
            List<TipoUsuarioEnum> tipoUsuarios = new List<TipoUsuarioEnum>();
            tipoUsuarios.Add(TipoUsuarioEnum.SIMIH_JEFE);

            if (!Helper.Helper.ValidarTipoUsuario(accessToken.GetUpn(), tipoUsuarios))
            {
                HttpContext.Current.Response.StatusCode = 401;
                HttpContext.Current.Response.Headers.Add("Unauthorized", "Basic realm=\"Acceso al sistema SIMIH\", charset=\"UTF-8\"");
                return -1;
            }

            Expedicion oExpedicion = new Expedicion()
            {
                ID = ID,
                idCalle = idCalle,
                idTipoExpedicion = idTipoExpedicion,
                IdCliente = IdCliente,
                Descripcion = Descripcion,
                Prefijo = Prefijo,
                Geo = Geo
            };

            return oExpedicion.NuevaExpedicion();
        }

        [WebMethod]
        public int ModificarExpedicion(int ID, int idCalle, int idTipoExpedicion, int IdCliente, string Descripcion, string Prefijo, string Geo)
        {
            AccessToken accessToken = new AccessToken(HttpContext.Current);
            List<TipoUsuarioEnum> tipoUsuarios = new List<TipoUsuarioEnum>();
            tipoUsuarios.Add(TipoUsuarioEnum.SIMIH_JEFE);

            if (!Helper.Helper.ValidarTipoUsuario(accessToken.GetUpn(), tipoUsuarios))
            {
                HttpContext.Current.Response.StatusCode = 401;
                HttpContext.Current.Response.Headers.Add("Unauthorized", "Basic realm=\"Acceso al sistema SIMIH\", charset=\"UTF-8\"");
                return -1;
            }

            Expedicion oExpedicion = new Expedicion()
            {
                ID = ID,
                idCalle = idCalle,
                idTipoExpedicion = idTipoExpedicion,
                IdCliente = IdCliente,
                Descripcion = Descripcion,
                Prefijo = Prefijo,
                Geo = Geo
            };

            return oExpedicion.ModificarExpedicion();
        }
        //2022
        [WebMethod]
        public int EliminarExpedicion(int ID)
        {
            AccessToken accessToken = new AccessToken(HttpContext.Current);
            List<TipoUsuarioEnum> tipoUsuarios = new List<TipoUsuarioEnum>();
            tipoUsuarios.Add(TipoUsuarioEnum.SIMIH_JEFE);

            if (!Helper.Helper.ValidarTipoUsuario(accessToken.GetUpn(), tipoUsuarios))
            {
                HttpContext.Current.Response.StatusCode = 401;
                HttpContext.Current.Response.Headers.Add("Unauthorized", "Basic realm=\"Acceso al sistema SIMIH\", charset=\"UTF-8\"");
                return -1;
            }

            Expedicion oExpedicion = new Expedicion()
            {
                ID = ID
            };

            return oExpedicion.EliminarExpedicion();
        }
        //2022
        [WebMethod]
        public int ActivarExpedicion(int ID)
        {
            AccessToken accessToken = new AccessToken(HttpContext.Current);
            List<TipoUsuarioEnum> tipoUsuarios = new List<TipoUsuarioEnum>();
            tipoUsuarios.Add(TipoUsuarioEnum.SIMIH_JEFE);

            if (!Helper.Helper.ValidarTipoUsuario(accessToken.GetUpn(), tipoUsuarios))
            {
                HttpContext.Current.Response.StatusCode = 401;
                HttpContext.Current.Response.Headers.Add("Unauthorized", "Basic realm=\"Acceso al sistema SIMIH\", charset=\"UTF-8\"");
                return -1;
            }

            Expedicion oExpedicion = new Expedicion()
            {
                ID = ID
            };
            return oExpedicion.ActivarExpedicion();
        }
    }
}
