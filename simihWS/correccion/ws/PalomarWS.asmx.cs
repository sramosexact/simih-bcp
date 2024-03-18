using Interna.Entity;
using simihWS.Helper;
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Services;

namespace simihWS
{
    /// <summary>
    /// Descripción breve de PalomarWS
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    [System.Web.Script.Services.ScriptService]
    public class PalomarWS : System.Web.Services.WebService
    {
        #region PALOMAR
        [WebMethod]
        public List<Geo> GetPalomarExpedicionGeo(int Id)
        {
            Palomar oPalomar = new Palomar();
            return oPalomar.rListaExpedicionGeo(Id);
        }

        [WebMethod]
        public List<Geo> GetPalomarGrupoGeo(int Id)
        {
            Palomar oPalomar = new Palomar();
            return oPalomar.rListaGrupoGeo(Id);
        }

        [WebMethod]
        public List<Geo> GetPalomarGeo(int Id)
        {
            Palomar oPalomar = new Palomar();
            return oPalomar.rListaGeo(Id);
        }

        [WebMethod]
        public List<Palomar> GetPalomarExpedicion(int IdCliente, int IdExpedicion)
        {
            Palomar oPalomar = new Palomar();
            return oPalomar.rLista(IdCliente, IdExpedicion);
        }

        [WebMethod]
        public List<Palomar> GetPalomar()
        {
            Palomar oPalomar = new Palomar();
            return oPalomar.rLista(0, 0);
        }

        [WebMethod]
        public List<Palomar> GetPalomarGrupo(int IdExpedicion)
        {
            Palomar oPalomar = new Palomar();
            return oPalomar.rListaGrupo(IdExpedicion);
        }

        [WebMethod]
        public List<Palomar> GetPalomarGrupoTipo(int IdExpedicion, int IdTipoPalomar)
        {
            Palomar oPalomar = new Palomar();
            return oPalomar.rListaGrupoTipo(IdExpedicion, IdTipoPalomar);
        }

        [WebMethod]
        public List<Palomar> GetPalomarHijo(int IdExpedicion, int IdPalomarPadre)
        {
            Palomar oPalomar = new Palomar();
            return oPalomar.rListaPalomarHijo(IdExpedicion, IdPalomarPadre);
        }

        [WebMethod]
        public int SetPalomarExpedicion(Palomar oP)
        {
            return oP.uPalomar();
        }

        [WebMethod]
        public int SetPalomarGrupo(int IdExpedicion, int iTipoDestino)
        {
            Palomar oPalomar = new Palomar();
            return oPalomar.cPalomarGrupo(IdExpedicion, iTipoDestino);
        }

        [WebMethod]
        public int SetPalomar(int IdPadre)
        {
            Palomar oPalomar = new Palomar();
            return oPalomar.cPalomar(IdPadre);
        }

        [WebMethod]
        public int SetPalomarBorrar(int Id)
        {
            Palomar oPalomar = new Palomar();
            return oPalomar.dPalomar(Id);
        }

        [WebMethod]
        public int DeleteAsignacionPalomar(int Id)
        {
            Palomar oPalomar = new Palomar();
            return oPalomar.dAsignacionPalomar(Id);
        }

        [WebMethod]
        public int SetPalomarGrupoBorrar(int Id)
        {
            Palomar oPalomar = new Palomar();
            return oPalomar.dPalomarGrupo(Id);
        }

        [WebMethod]
        public List<Geo> GetListaGeoPorPalomar(int Id)
        {
            Palomar oPalomar = new Palomar();
            return oPalomar.rListaGeoPorPalomar(Id);
        }

        [WebMethod]
        public List<Geo> GetListaGeoPorAsignar(int Id)
        {
            Palomar oPalomar = new Palomar();
            return oPalomar.rListaGeoPorAsignar(Id);
        }

        [WebMethod]
        public int SetCrearPalomarGeo(int IdPalomar, int IdGeo, int IdExpedicion)
        {
            Palomar oPalomar = new Palomar();
            return oPalomar.rCrearPalomarGeo(IdPalomar, IdGeo, IdExpedicion);
        }


        [WebMethod]
        public List<Geo> rGeoLista(int Id, int RecordIndex, int Width)
        {
            Palomar oPal = new Palomar();
            return oPal.rListarGeoPalomar(Id, RecordIndex, Width);
        }

        [WebMethod]
        public int rGeoListaContar(int Id)
        {
            Palomar oPal = new Palomar();
            return oPal.rListarGeoPalomarContar(Id);
        }
        //2022
        [WebMethod]
        public String rPalomaresExpedicionJSON(int iExpedicion, int iTipoDestino)
        {
            Palomar oPal = new Palomar();
            return oPal.rListarPalomaresExpedicionJSON(iExpedicion, iTipoDestino);
        }
        /*CBALTAZAR 01/09/2015*/
        [WebMethod]
        public String rListaPalomarJSON(int iCliente, int iExpedicion)
        {
            Palomar oPal = new Palomar();
            return oPal.rListaPalomarJSON(iCliente, iExpedicion);
        }
        /*CBALTAZAR 05/10/2015*/
        [WebMethod]
        public List<String> rListaGeoPalomarPorTipoDestinoJSON(int iExpedicion, int iPalomar, int iTipoDestino)
        {
            Palomar oPalomar = new Palomar();
            return oPalomar.rListaGeoPorTipoDestinoJSON(iExpedicion, iPalomar, iTipoDestino);
        }
        //2022
        [WebMethod]
        public string ListaPalomarHijo(int IdExpedicion, int IdPalomarPadre)
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
            Palomar oPal = new Palomar();
            return oPal.ListaPalomarHijo(IdExpedicion, IdPalomarPadre);
        }

        //VILLARREAL 02/10/2015
        [WebMethod]
        public String rListaPalomarGrupoJson(int idExpedicion)
        {
            Palomar oPal = new Palomar();
            return oPal.rListaPalomarGrupoJSON(idExpedicion);
        }
        //2022
        [WebMethod]
        public String rListaPalomarPorGrupoJSON(int idExpedicion, int idGrupo)
        {
            Palomar oPal = new Palomar();
            return oPal.rListaPalomarPorGrupoJSON(idExpedicion, idGrupo);
        }
        //2022
        [WebMethod]
        public string rListaPalomarGrupoPisosJSON(int idExpedicion)
        {
            Palomar oPal = new Palomar();
            return oPal.rListaPalomarGrupoPisosJSON(idExpedicion);
        }

        /*CBALTAZAR 24/11/2015*/
        [WebMethod]
        public String rListaPalomarGrupoAgenciaJSON(int IdExpedicion)
        {
            Palomar oPal = new Palomar();
            return oPal.rListaPalomarGrupoAgenciaJSON(IdExpedicion);
        }
        //2022
        [WebMethod]
        public string rObtenerPalomaresEntregaAsociados(int idEntrega)
        {
            Palomar oPal = new Palomar();
            return oPal.rObtenerPalomaresEntregaAsociados(idEntrega);
        }
        //2022
        [WebMethod]
        public int rVerificarAutogeneradoValidadosPorPalomares(string detalle, int identrega)
        {
            Palomar oPal = new Palomar();
            return oPal.rVerificarAutogeneradoValidadosPorPalomares(detalle, identrega);
        }
        /*César 14/09/2016*/
        [WebMethod]
        public List<String> ListarGeoPalomar(Palomar oPalomar)
        {
            return oPalomar.ListarGeoPalomar();
        }
        //2022
        [WebMethod]
        public int NuevoPalomarGrupo(int IdExpedicion, int iTipoDestino)
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
            Palomar oPalomar = new Palomar();
            return oPalomar.NuevoPalomarGrupo(IdExpedicion, iTipoDestino);
        }
        //2022
        [WebMethod]
        public int NuevoPalomar(int IdPadre)
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
            Palomar oPalomar = new Palomar();
            return oPalomar.NuevoPalomar(IdPadre);
        }
        //2022
        [WebMethod]
        public int VincularPalomarPuntoEntrega(int IdPalomar, int IdGeo, int IdExpedicion)
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
            Palomar oPalomar = new Palomar();
            return oPalomar.VincularPalomarPuntoEntrega(IdPalomar, IdGeo, IdExpedicion);
        }
        //2022
        [WebMethod]
        public int EliminarPalomar(int Id)
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
            Palomar oPalomar = new Palomar();
            return oPalomar.EliminarPalomar(Id);
        }
        //2022
        [WebMethod]
        public string ListarPalomares(int iCliente, int iExpedicion)
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
            Palomar oPal = new Palomar();
            return oPal.ListarPalomares(iCliente, iExpedicion);
        }
        //2022
        [WebMethod]
        public int DesvincularPalomarPuntoEntrega(int Id)
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
            Palomar oPalomar = new Palomar();
            return oPalomar.DesvincularPalomarPuntoEntrega(Id);
        }
        //2022
        [WebMethod]
        public int ModificarPalomar(string sDescripcion, int iId, int iIdPadre)
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
            Palomar oP = new Palomar();
            return oP.ModificarPalomar(sDescripcion, iId, iIdPadre);
        }

        //2022
        [WebMethod]
        public int EliminarGrupoPalomar(int Id)
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
            Palomar oPalomar = new Palomar();
            return oPalomar.EliminarGrupoPalomar(Id);
        }
        //2022
        [WebMethod]
        public String ListarPalomaresAgencia(int iExpedicion)
        {
            Palomar oPal = new Palomar();
            return oPal.ListarPalomaresAgencia(iExpedicion);
        }
        //2022
        [WebMethod]
        public string ListarGeoPorPalomar(int iIdPalomar)
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
            Palomar oPal = new Palomar();
            return oPal.ListarGeoPorPalomar(iIdPalomar);
        }
        //2022
        [WebMethod]
        public string ListarGeoPorAsociarAlPalomar(int iIdExpedicion)
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
            Palomar oPal = new Palomar();
            return oPal.ListarGeoPorAsociarAlPalomar(iIdExpedicion);
        }

        #endregion
    }
}
